using System.Collections.Generic;

namespace AOC._2021
{
    class Day05 : TestClass, ITestClass
    {
        private readonly string[] _readings;
        public Day05()
        {
            _input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";
            _readings = GetVerticalSplitLines();
        }

        public object Task1()
        {
            HashSet<(int, int)> plots = new();
            HashSet<(int, int)> intersects = new();

            foreach(var line in _readings)
            {
                var split = line.Split(" -> ");
                var from = ReadCoordString(split[0]);
                var to = ReadCoordString(split[1]);

                if (!(from.x == to.x || from.y == to.y)) continue;

                (int x, int y) now = from;
                do
                {
                    if (!plots.Add(now))
                    {
                        intersects.Add(now);
                    }
                }
                while (TryMove(now, to, out now));
            }

            return intersects.Count;
        }

        public object Task2()
        {
            HashSet<(int, int)> plots = new();
            HashSet<(int, int)> intersects = new();

            foreach (var line in _readings)
            {
                var split = line.Split(" -> ");
                var from = ReadCoordString(split[0]);
                var to = ReadCoordString(split[1]);

                (int x, int y) now = from;
                do
                {
                    if (!plots.Add(now))
                    {
                        intersects.Add(now);
                    }
                }
                while (TryMove(now, to, out now));
            }

            return intersects.Count;
        }

        private static (int x, int y) ReadCoordString(string coord)
        {
            string[] split = coord.Split(',');
            return (int.Parse(split[0]), int.Parse(split[1]));
        }

        private static bool TryMove((int x, int y) now, (int x, int y) to, out (int x, int y) move)
        {
            bool moved = false;

            move.x = to.x;
            move.y = to.y;

            if (now.y < to.y)
            {
                move.y = now.y + 1;
                moved = true;
            }
            else if (now.y > to.y)
            {
                move.y = now.y - 1;
                moved = true;
            }

            if (now.x < to.x)
            {
                move.x = now.x + 1;
                moved = true;
            }
            else if (now.x > to.x)
            {
                move.x = now.x - 1;
                moved = true;
            }

            return moved;
        }
    }
}
