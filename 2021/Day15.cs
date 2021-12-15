using Priority_Queue;
using System.Collections.Generic;

namespace AOC._2021
{
    class Day15 : TestClass, ITestClass
    {
        private int _maxX;
        private int _maxY;
        private Dictionary<(int x, int y), Node> _readings;

        public Day15()
        {
            _input = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";
        }

        private void ParseInputPart1()
        {
            string[] lines = GetVerticalSplitLines();

            _maxX = lines[0].Length;
            _maxY = lines.Length;
            _readings = new();

            for (int y = 0; y < _maxY; y++)
            {
                for (int x = 0; x < _maxX; x++)
                {
                    var coord = (x, y);
                    _readings.Add(coord, new Node(coord, value: int.Parse(lines[y][x].ToString())));
                }
            }
        }

        public object Task1()
        {
            ParseInputPart1();
            return FindPath();
        }

        private void ParseInputPart2()
        {
            int scale = 5;

            string[] lines = GetVerticalSplitLines();

            int maxXTile = lines[0].Length;
            int maxYTile = lines.Length;

            _maxX = maxXTile * scale;
            _maxY = maxYTile * scale;
            _readings = new();

            //Scale out horizontally
            for (int y = 0; y < maxYTile; y++)
            {
                for (int x = 0; x < maxXTile; x++)
                {
                    int value = int.Parse(lines[y][x].ToString());

                    int scaleX = 0;
                    while (scaleX < scale)
                    {
                        var coord = (x: x + (maxXTile * scaleX), y);
                        _readings.Add(coord, new Node(coord, value: value));

                        if (++value == 10)
                        {
                            value = 1;
                        }
                        scaleX++;
                    }
                }
            }

            //Scale vertically
            for(int y = maxYTile; y < _maxY; y++)
            {
                for(int x = 0; x < _maxX; x++)
                {
                    var sourceCoord = (x, y: y % maxYTile);
                    int value = _readings[sourceCoord].Value;

                    value += (y / maxYTile);
                    if(value >= 10)
                    {
                        value = 1 + value - 10;
                    }

                    var coord = (x, y);
                    _readings.Add(coord, new Node(coord, value: value));
                }
            }
        }

        public object Task2()
        {
            ParseInputPart2();
            return FindPath();
        }

        private object FindPath()
        {
            Node origin = _readings[(0, 0)];
            origin.Distance = 0;

            SimplePriorityQueue<Node> queue = new();
            queue.Enqueue(origin, 0);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Visited) continue;

                node.Visited = true;

                var siblings = new (int x, int y)[]
                {
                    (node.Coords.X - 1, node.Coords.Y),
                    (node.Coords.X + 1, node.Coords.Y),
                    (node.Coords.X,     node.Coords.Y - 1),
                    (node.Coords.X,     node.Coords.Y + 1),
                };

                foreach ((int x, int y) in siblings)
                {
                    if (_readings.TryGetValue((x, y), out Node sibling) && !sibling.Visited)
                    {
                        int distance = node.Distance + sibling.Value;
                        if (distance < sibling.Distance)
                        {
                            sibling.Distance = distance;
                            queue.Enqueue(sibling, sibling.Distance);
                        }
                    }
                }
            }

            return _readings[(_maxX - 1, _maxY - 1)].Distance;
        }

        class Node
        {
            public (int X, int Y) Coords { get; set; }
            public int Value { get; }
            public int Distance { get; set; }
            public bool Visited { get; set; }

            public Node((int, int) coords, int value)
            {
                Coords = coords;
                Value = value;
                Distance = int.MaxValue;
            }
        }
    }
}
