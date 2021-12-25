using System.Collections.Generic;

namespace AOC._2021
{
    class Day25 : TestClass, ITestClass
    {
        private Dictionary<(int x, int y), bool> _cucumbers = new();
        private readonly int _maxY;
        private readonly int _maxX;

        private const char EastChar = '>';
        private const char SouthChar = 'v';

        public Day25()
        {
            _input = ReadInputFile(useDemo: false);
            string[] lines = GetVerticalSplitLines();
            for(int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                for(int x = 0; x < line.Length; x++)
                {
                    if(line[x] == EastChar)
                    {
                        _cucumbers.Add((x, y), true);
                    }
                    else if(line[x] == SouthChar)
                    {
                        _cucumbers.Add((x, y), false);
                    }
                }
            }

            _maxY = lines.Length;
            _maxX = lines[0].Length;
        }

        public object Task1()
        {
            int moveCount = int.MaxValue;
            int steps = 0;

            while(moveCount > 0)
            {
                moveCount = 0;

                Dictionary<(int, int), bool> moved = new(_cucumbers);

                for(int y = 0; y < _maxY; y++)
                {
                    for(int x = 0; x < _maxX; x++)
                    {
                        if (_cucumbers.TryGetValue((x, y), out bool type) && type)
                        {
                            int nextX = NextX(x);

                            if (!_cucumbers.ContainsKey((nextX, y)))
                            {
                                moved.Add((nextX, y), type);
                                moved.Remove((x, y));
                                moveCount++;
                            }
                        }
                    }
                }

                _cucumbers = moved;
                moved = new(moved);

                for (int x = 0; x < _maxX; x++)
                {
                    for (int y = 0; y < _maxY; y++)
                    {
                        if (_cucumbers.TryGetValue((x, y), out bool type) && !type)
                        {
                            int nextY = NextY(y);

                            if (!_cucumbers.ContainsKey((x, nextY)))
                            {
                                moved.Add((x, nextY), type);
                                moved.Remove((x, y));
                                moveCount++;
                            }
                        }
                    }
                }

                _cucumbers = moved;
                steps++;
            }

            return steps;
        }

        public object Task2()
        {
            return 0;
        }

        private int NextX(int x)
        {
            if(++x == _maxX)
            {
                x = 0;
            }
            return x;
        }

        private int NextY(int y)
        {
            if(++y == _maxY)
            {
                y = 0;
            }
            return y;
        }
    }
}
