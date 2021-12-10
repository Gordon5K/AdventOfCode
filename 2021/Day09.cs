using System.Collections.Generic;
using System.Linq;

namespace AOC._2021
{
    class Day09 : TestClass, ITestClass
    {
        private readonly Dictionary<(int x, int y), int> _readings;
        private readonly int _maxX = 0;
        private readonly int _maxY = 0;

        public Day09()
        {
            _input = @"2199943210
                       3987894921
                       9856789892
                       8767896789
                       9899965678";

            _readings = new Dictionary<(int x, int y), int>();

            string[] lines = GetVerticalSplitLines();

            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                int x = 0;
                for (int x1 = 0; x1 < line.Length; x1++)
                {
                    char c = line[x1];
                    if (c == ' ') continue;
                    _readings.Add((x, y), int.Parse(c.ToString()));
                    x++;
                }
                if (y == 0) _maxX = x;
            }

            _maxY = lines.Length;
        }

        public object Task1()
        {
            var xLows = FindLowXPoints();
            var lows = FindLows(xLows);

            int score = 0;
            foreach ((int x, int y) in lows)
            {
                score += (1 + _readings[(x, y)]);
            }

            return score;
        }

        private HashSet<(int x, int y)> FindLows(HashSet<(int x, int y)> xLows)
        {
            var lows = new HashSet<(int x, int y)>();

            foreach ((int x, int y) in xLows)
            {
                bool lowUp = false;
                bool lowDown = false;
                if (y == _maxY - 1 || _readings[(x, y)] < _readings[(x, y + 1)])
                {
                    lowDown = true;
                }
                if (y == 0 || _readings[(x, y)] < _readings[(x, y - 1)])
                {
                    lowUp = true;
                }

                if (lowUp && lowDown)
                {
                    lows.Add((x, y));
                }
            }

            return lows;
        }

        private HashSet<(int x, int y)> FindLowXPoints()
        {
            var lows = new HashSet<(int x, int y)>();
            for (int y = 0; y < _maxY; y++)
            {
                for (int x = 0; x < _maxX; x++)
                {
                    bool lowLeft = false;
                    bool lowRight = false;
                    if (x == _maxX - 1 || _readings[(x, y)] < _readings[(x + 1, y)])
                    {
                        lowRight = true;
                    }
                    if (x == 0 || _readings[(x, y)] < _readings[(x - 1, y)])
                    {
                        lowLeft = true;
                    }

                    if (lowLeft && lowRight)
                    {
                        lows.Add((x, y));
                    }

                    if (lowRight)
                    {
                        x++;
                    }
                }
            }

            return lows;
        }

        public object Task2()
        {
            var xLows = FindLowXPoints();
            var lows = FindLows(xLows);

            List<int> sizes = new();

            foreach (var low in lows)
            {
                Queue<(int, int)> queue = new();

                HashSet<(int, int)> inBasin = new();
                HashSet<(int, int)> seen = new();

                queue.Enqueue(low);
                inBasin.Add(low);

                while (queue.Count > 0)
                {
                    (int x, int y) point = queue.Dequeue();

                    seen.Add(point);

                    if (point.x < _maxX -1)
                    {
                        var rightPoint = (point.x + 1, point.y);
                        if (!seen.Contains(rightPoint) && _readings[rightPoint] != 9)
                        {
                            inBasin.Add(rightPoint);
                            queue.Enqueue(rightPoint);
                        }
                    }

                    if(point.x > 0)
                    {
                        var leftPoint = (point.x - 1, point.y);
                        if (!seen.Contains(leftPoint) && _readings[leftPoint] != 9)
                        {
                            inBasin.Add(leftPoint); 
                            queue.Enqueue(leftPoint);
                        }
                    }

                    if (point.y < _maxY - 1)
                    {
                        var downPoint = (point.x, point.y + 1);
                        if (!seen.Contains(downPoint) && _readings[downPoint] != 9)
                        {
                            inBasin.Add(downPoint);
                            queue.Enqueue(downPoint);
                        }
                    }

                    if (point.y > 0)
                    {
                        var upPoint = (point.x, point.y - 1);
                        if (!seen.Contains(upPoint) && _readings[upPoint] != 9)
                        {
                            inBasin.Add(upPoint);
                            queue.Enqueue(upPoint);
                        }
                    }
                }

                sizes.Add(inBasin.Count);
            }

            int totalScore = 1;
            foreach (int score in sizes.OrderByDescending(x => x).Take(3))
            {
                totalScore *= score;
            }

            return totalScore;
        }
    }
}
