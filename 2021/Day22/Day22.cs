using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AOC._2021
{
    class Day22 : TestClass, ITestClass
    {
        private readonly string _instructionPattern = new(@"(on|off) x=(-?\d+)..(-?\d+),y=(-?\d+)..(-?\d+),z=(-?\d+)..(-?\d+)");
        
        public Day22()
        {
            _input = ReadInputFile(useDemo: false);
        }

        private List<Instruction> ReadInstructions()
        {
            string[] lines = GetVerticalSplitLines();

            List<Instruction> instructions = new();
            foreach(var line in lines)
            {
                var matches = Regex.Matches(line, _instructionPattern);
                instructions.Add(new Instruction(
                    Enum.Parse<PowerState>(matches[0].Groups[1].ToString()),
                    int.Parse(matches[0].Groups[2].ToString()),
                    int.Parse(matches[0].Groups[3].ToString()),
                    int.Parse(matches[0].Groups[4].ToString()),
                    int.Parse(matches[0].Groups[5].ToString()),
                    int.Parse(matches[0].Groups[6].ToString()),
                    int.Parse(matches[0].Groups[7].ToString())));
            }
            return instructions;
        }

        public object Task1()
        {
            const int minBound = -50;
            const int maxBound = 50;
            HashSet<Cuboid> enabledCuboids = ExecuteReboot();

            ulong withinBounds = 0;
            foreach (Cuboid cuboid in enabledCuboids)
            {
                withinBounds += cuboid.CubeCountWithinBounds(minBound, maxBound, minBound, maxBound, minBound, maxBound);
            }
            return withinBounds;
        }

        public object Task2()
        {
            HashSet<Cuboid> enabledCuboids = ExecuteReboot();

            ulong count = 0;
            foreach (Cuboid cuboid in enabledCuboids)
            {
                count += cuboid.CubeCount;
            }
            return count;
        }

        private HashSet<Cuboid> ExecuteReboot()
        {
            HashSet<Cuboid> enabledCuboids = new();

            foreach (var instruction in ReadInstructions())
            {
                Cuboid newBlock = new(instruction.X0, instruction.X1, instruction.Y0, instruction.Y1, instruction.Z0, instruction.Z1);

                HashSet<Cuboid> splits = new();
                HashSet<Cuboid> removed = new();

                foreach (Cuboid curBlock in enabledCuboids)
                {
                    if (curBlock.Intersects(newBlock))
                    {
                        var split = SplitCuboid(curBlock, newBlock);
                        splits.UnionWith(split);
                        removed.Add(curBlock);
                    }
                }

                enabledCuboids.RemoveWhere(x => removed.Contains(x));
                enabledCuboids.UnionWith(splits);
                if (instruction.PowerState == PowerState.on)
                {
                    enabledCuboids.Add(newBlock);
                }
            }

            return enabledCuboids;
        }

        private static HashSet<Cuboid> SplitCuboid(Cuboid block1, Cuboid block2)
        {
            //Subtract block2 from block 1 and return all the new cuboids
            HashSet<Cuboid> cubes = new();

            if (block2.X0 >= block1.X0)
            {
                cubes.Add(block1.ChangeX(block1.X0, block2.X0 - 1));
                block1 = block1.ChangeX(block2.X0, block1.X1);
            }

            if (block2.X1 <= block1.X1)
            {
                cubes.Add(block1.ChangeX(block2.X1 + 1, block1.X1));
                block1 = block1.ChangeX(block1.X0, block2.X1);
            }

            if (block2.Y0 >= block1.Y0)
            {
                cubes.Add(block1.ChangeY(block1.Y0, block2.Y0 - 1));
                block1 = block1.ChangeY(block2.Y0, block1.Y1);
            }

            if (block2.Y1 <= block1.Y1)
            {
                cubes.Add(block1.ChangeY(block2.Y1 + 1, block1.Y1));
                block1 = block1.ChangeY(block1.Y0, block2.Y1);
            }

            if (block2.Z0 >= block1.Z0)
            {
                cubes.Add(block1.ChangeZ(block1.Z0, block2.Z0 - 1));
                block1 = block1.ChangeZ(block2.Z0, block1.Z1);
            }

            if (block2.Z1 <= block1.Z1)
            {
                cubes.Add(block1.ChangeZ(block2.Z1 + 1, block1.Z1));
            }

            return cubes;
        }

        enum PowerState { on, off };

        record Cuboid(int X0, int X1, int Y0, int Y1, int Z0, int Z1)
        {
            private static ulong Size(int x0, int x1, int y0, int y1, int z0, int z1) => (ulong)(x1 - x0 + 1) * (ulong)(y1 - y0 + 1) * (ulong)(z1 - z0 + 1);

            public ulong CubeCount => Size(X0, X1, Y0, Y1, Z0, Z1);

            public ulong CubeCountWithinBounds(int x0, int x1, int y0, int y1, int z0, int z1)
            {
                //Out of plane
                if (X1 < x0 || X0 > x1 || Y1 < y0 || Y0 > y1 || Z1 < z0 || Z0 > z1) return 0;

                //Detect partially out of plane
                int minX = X0 < x0 ? x0 : X0;
                int minY = Y0 < y0 ? y0 : Y0;
                int minZ = Z0 < z0 ? z0 : Z0;

                int maxX = X1 > x1 ? x1 : X1;
                int maxY = Y1 > y1 ? y1 : Y1;
                int maxZ = Z1 > z1 ? z1 : Z1;

                return Size(minX, maxX, minY, maxY, minZ, maxZ);
            }

            public bool Intersects(Cuboid other)
            {
                return other.X1 >= X0 &&
                        other.X0 <= X1 &&
                        other.Y1 >= Y0 &&
                        other.Y0 <= Y1 &&
                        other.Z1 >= Z0 &&
                        other.Z0 <= Z1;
            }

            public Cuboid ChangeX(int x0, int x1) => this with { X0 = x0, X1 = x1 };
            public Cuboid ChangeY(int y0, int y1) => this with { Y0 = y0, Y1 = y1 };
            public Cuboid ChangeZ(int z0, int z1) => this with { Z0 = z0, Z1 = z1 };
        }
        record Instruction(PowerState PowerState, int X0, int X1, int Y0, int Y1, int Z0, int Z1);

    }
}
