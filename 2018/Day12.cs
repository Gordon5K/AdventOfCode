using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC._2018
{
    class Day12
    {
//        readonly string _input = @"initial state: #..#.#..##......###...###

//...## => #
//..#.. => #
//.#... => #
//.#.#. => #
//.#.## => #
//.##.. => #
//.#### => #
//#.#.# => #
//#.### => #
//##.#. => #
//##.## => #
//###.. => #
//###.# => #
//####. => #"

        readonly string _input = @"initial state: #.#.#..##.#....#.#.##..##.##..#..#...##....###..#......###.#..#.....#.###.#...#####.####...#####.#.#

..#.. => .
#...# => .
.#... => #
#.##. => .
..#.# => #
#.#.# => .
###.. => #
###.# => #
..... => .
....# => .
.##.. => #
##### => .
####. => .
..##. => .
##.#. => #
.#..# => #
##..# => .
.##.# => .
.#### => #
..### => .
...## => #
#..## => #
#.... => .
##.## => .
#.#.. => .
##... => .
.#.## => #
.###. => #
...#. => .
#.### => .
#..#. => #
.#.#. => .";

        private Input GetLines()
        {
            var lines = _input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Input result = new()
            {
                State = new StringBuilder("....." + lines[0].Replace("initial state: ", "") + "....."),
                Instructions = lines.Skip(1).ToArray()
            };

            return result;
        }

        readonly Dictionary<long, long> _scores = new();

        readonly long _iterations = 50000000000;
        

        private void GetValues()
        {
            long _diff3, _diff2, _diff1 = 0;

            Input input = GetLines();

            for(int i = 0; i < _iterations; i++)
            {
                input.NextState = input.State;

                for (int c = 0; c < input.State.Length - 6; c++)
                {
                    string subString = input.State.ToString().Substring(c, 5);

                    bool matched = false;
                    bool isSuccess = false;
                    foreach (string inst in input.Instructions)
                    {
                        string instruction = inst.Substring(0, 5);
                        string result = inst.Substring(inst.Length - 1, 1); //This is key

                        if (subString == instruction)
                        {
                            matched = true;
                            if(!isSuccess) isSuccess = result == "#";
                        }
                    }

                    int index = c + 2;
                    if (matched)
                    {
                        string nextState = input.NextState.ToString();
                        input.NextState.Append(nextState.Substring(0, index) + (isSuccess ? "#" : ".") + nextState[(index + 1)..]);
                    }
                    else
                    {
                        string nextState = input.NextState.ToString();
                        input.NextState.Append(nextState.Substring(0, index) + "." + nextState[(index + 1)..]);
                    }
                }

                input.State = input.NextState;
                if(input.State.ToString().Substring(input.State.Length - 5, 5).Contains("#"))
                {
                    input.State.Append("....."); 
                }

                long score = 0;
                for (int c = 0; c < input.State.Length; c++)
                {
                    int pot = c + input.StartIndex;
                    if (input.State[c].ToString() == "#")
                    {
                        score += pot;
                    }
                }

                int count = i + 1;
                _scores.Add(count, score);

                if(i > 10)
                {
                    _diff1 = _scores[count] - _scores[count - 1];
                    _diff2 = _scores[count - 1] - _scores[count - 2];
                    _diff3 = _scores[count - 2] - _scores[count - 3];

                    if(_diff1 == _diff2 && _diff2 == _diff3)
                    {
                        long result = score + ((_iterations - count) * _diff1);
                        return;
                    }
                }
            }
            
        }

        public string Task1()
        {
            GetValues();
            return "";
        }

        public string Task2() => Task1();
    }

    class Input
    {
        public StringBuilder State;
        public StringBuilder NextState;
        public int StartIndex = -5;
        public string[] Instructions;
    }
}
