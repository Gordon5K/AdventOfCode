using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC._2021
{
    class Day24 : TestClass, ITestClass
    {
        private readonly CommandSequence[] _commands;
        private const char Z = 'z';

        public Day24()
        {
            _input = ReadInputFile(useDemo: false);

            List<CommandSequence> chunks = new();
            List<Command> chunk = null;

            byte s = 0;
            string[] lines = GetVerticalSplitLines();
            for (byte i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(' ');
                var type = Enum.Parse<CommandType>(parts[0]);

                char a = parts[1][0];

                if(parts.Length == 2)
                {
                    if(chunk != null)
                    {
                        chunks.Add(new CommandSequence(s++, chunk.ToArray()));
                    }

                    chunk = new();
                    chunk.Add(new Command(type, a));
                }
                else if(sbyte.TryParse(parts[2], out sbyte value))
                {
                    chunk.Add(new NumericCommand(type, a, value));
                }
                else
                {
                    chunk.Add(new TokenCommand(type, a, parts[2][0]));
                }
            }

            chunks.Add(new CommandSequence(s, chunk.ToArray()));
            _commands = chunks.ToArray();
        }

        public object Task1()
        {
            return Calculate(MinMax.Max);
        }

        public object Task2()
        {
            return Calculate(MinMax.Min);
        }

        private long Calculate(MinMax type)
        {
            int[] result = new int[14];

            Stack<CommandSequence> stack = new();

            foreach(CommandSequence sequence in _commands)
            {
                if (sequence.CanGrow)
                {
                    stack.Push(sequence);
                }
                else
                {
                    CommandSequence openSequence = stack.Pop();

                    int pair1, pair2;
                    if (type == MinMax.Max)
                    {
                        (pair1, pair2) = FindSequencePairMax(openSequence, sequence);
                    }
                    else
                    {
                        (pair1, pair2) = FindSequencePairMin(openSequence, sequence);
                    }
                    
                    result[openSequence.Sequence] = pair1;
                    result[sequence.Sequence] = pair2;
                }
            }

            return ArrayToLong(result);
        }

        private static (int pair1, int pair2) FindSequencePairMax(CommandSequence openSequence, CommandSequence sequence)
        {
            for (int i = 9; i > 0; i--)
            {
                AluValue value = new();
                ExecuteCommand(openSequence, value, i);

                for (int j = 9; j > 0; j--)
                {
                    AluValue newValue = value.Copy();
                    ExecuteCommand(sequence, newValue, j);
                    if (newValue[Z] == 0)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }

        private static (int pair1, int pair2) FindSequencePairMin(CommandSequence openSequence, CommandSequence sequence)
        {
            for (int i = 1; i < 10; i++)
            {
                AluValue value = new();
                ExecuteCommand(openSequence, value, i);

                for (int j = 1; j < 10; j++)
                {
                    AluValue newValue = value.Copy();
                    ExecuteCommand(sequence, newValue, j);
                    if (newValue[Z] == 0)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }

        private static void ExecuteCommand(CommandSequence commandSequence, AluValue value, int num)
        {
            foreach (Command cmd in commandSequence.Commands)
            {
                if (cmd.Type == CommandType.inp)
                {
                    value[cmd.A] = num;
                    continue;
                }

                long opValue = cmd switch
                {
                    NumericCommand n => n.Value,
                    TokenCommand t => value[t.B],
                    _ => throw new InvalidOperationException()
                };

                switch (cmd.Type)
                {
                    case CommandType.add:
                        value[cmd.A] += opValue;
                        break;
                    case CommandType.mul:
                        value[cmd.A] *= opValue;
                        break;
                    case CommandType.div:
                        value[cmd.A] /= opValue;
                        break;
                    case CommandType.mod:
                        value[cmd.A] %= opValue;
                        break;
                    case CommandType.eql:
                        value[cmd.A] = value[cmd.A] == opValue ? 1 : 0;
                        break;
                }
            }
        }

        private static long ArrayToLong(int[] arr)
        {
            long l = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                l *= 10;
                l += arr[i];
            }
            return l;
        }

        enum MinMax
        {
            Min,
            Max
        }

        enum CommandType
        {
            inp,
            add,
            mul,
            div,
            mod,
            eql
        }

        record Command(CommandType Type, char A);

        record NumericCommand(CommandType Type, char A, sbyte Value) 
            : Command(Type, A);

        record TokenCommand(CommandType Type, char A, char B)
            : Command(Type, A);

        struct CommandSequence
        {
            public byte Sequence { get; }
            public Command[] Commands { get; }
            public bool CanGrow { get; }

            public CommandSequence(byte sequence, Command[] commands)
            {
                Sequence = sequence;
                Commands = commands;
                CanGrow = commands.Any(x => x is NumericCommand n && x.Type == CommandType.div && n.Value == 1);
            }
        }

        class AluValue
        {
            private readonly Dictionary<char, byte> _inputIndex = new()
            {
                ['w'] = 0,
                ['x'] = 1,
                ['y'] = 2,
                ['z'] = 3,
            };

            public long[] Values { get; } = new long[4];

            public long this[char c]
            {
                get => Values[_inputIndex[c]];
                set => Values[_inputIndex[c]] = value;
            }

            public AluValue() { }
            public AluValue(long[] values)
            {
                Values = values;
            }

            public AluValue Copy()
            {
                return new AluValue(Values.Clone() as long[]);
            }
        }
    }
}
