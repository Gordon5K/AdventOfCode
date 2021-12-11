using System.Collections.Generic;

namespace AOC._2021
{
    class Day11 : TestClass, ITestClass
    {
        private readonly Dictionary<(int, int), int> _readings = new();
        private readonly int _maxX, _maxY;
        
        public Day11()
        {
            _input = @"4585612331
5863566433
6714418611
1746467322
6161775644
6581631662
1247161817
8312615113
6751466142
1161847732";
            var lines = GetVerticalSplitLines();
            _maxX = lines[0].Length;
            _maxY = lines.Length;

            for (int y = 0; y < _maxY; y++)
            {
                for (int x = 0; x < _maxX; x++)
                {
                    _readings.Add((x, y), int.Parse(lines[y][x].ToString()));
                }
            }
        }

        public object Task1()
        {
            int ticks = 100;
            int total = 0;

            for (int i = 0; i < ticks; i++)
            {
                var flashed = new HashSet<(int, int)>();
                var queue = new Queue<(int x, int y)>();

                for (int y = 0; y < _maxY; y++)
                {
                    for (int x = 0; x < _maxX; x++)
                    {
                        var point = (x, y);
                        if (++_readings[point] > 9)
                        {
                            queue.Enqueue(point);
                        }
                    }
                }

                WorkQueue(flashed, queue);
                total += flashed.Count;
            }

            return total;
        }

        public object Task2()
        {
            int ticks = 100; //100 passes have already happened in part 1
            HashSet<(int, int)> flashed;
            do
            {
                ticks++;
                flashed = new HashSet<(int, int)>();
                var queue = new Queue<(int x, int y)>();

                for (int y = 0; y < _maxY; y++)
                {
                    for (int x = 0; x < _maxX; x++)
                    {
                        var point = (x, y);
                        if (++_readings[point] > 9)
                        {
                            queue.Enqueue(point);
                        }
                    }
                }

                WorkQueue(flashed, queue);
            }
            while (flashed.Count != _readings.Count);

            return ticks;
        }

        private void WorkQueue(HashSet<(int, int)> flashed, Queue<(int x, int y)> queue)
        {
            while (queue.Count > 0)
            {
                var point = queue.Dequeue();

                flashed.Add(point);
                _readings[point] = 0;

                foreach (var sibling in GetSiblings(point))
                {
                    if (!flashed.Contains(sibling) && ++_readings[sibling] == 10)
                    {
                        queue.Enqueue(sibling);
                    }
                }
            }
        }

        private IEnumerable<(int x, int y)> GetSiblings((int x, int y) point)
        {
            (int x, int y) = point;
            for (int xI = x - 1; xI < x + 2; xI++)
            {
                for (int yI = y - 1; yI < y + 2; yI++)
                {
                    if (_readings.ContainsKey((xI, yI)))
                    {
                        yield return ((xI, yI));
                    }
                }
            }
        }
    }
}
