using System;
using System.Collections.Generic;

namespace AOC._2021
{
    class Day13 : TestClass, ITestClass
    {
        private int _width = 0, _height = 0;
        private readonly HashSet<(int x, int y)> _points = new();
        private readonly List<(char direction, int position)> _folds = new();

        private const char YAxis = 'y';
        private const char XAxis = 'x';

        public Day13()
        {
            _input = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";
            string[] lines = GetVerticalSplitLines();

            bool readingCoord = true;
            foreach(var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    readingCoord = false;
                    continue;
                }

                if (readingCoord)
                {
                    var coordSplit = line.Split(',');
                    _points.Add((int.Parse(coordSplit[0]), int.Parse(coordSplit[1])));
                }
                else
                {
                    var instruction = line.Replace("fold along ", "");
                    var instructionSplit = instruction.Split('=');
                    _folds.Add((instructionSplit[0][0], int.Parse(instructionSplit[1])));
                }
            }
        }

        public object Task1()
        {
            (char direction, int foldLine) = _folds[0];
            Fold(direction, foldLine);

            return _points.Count;
        }

        public object Task2()
        {
            //Continues after part 1
            for (int i = 1; i < _folds.Count; i++)
            {
                (char direction, int foldLine) = _folds[i];
                Fold(direction, foldLine);
            }

            DrawPoints();

            return _points.Count;
        }

        private void Fold(char direction, int foldLine)
        {
            List<(int, int)> newPoints = new();
            List<(int, int)> deadPoints = new();

            bool verticalFold = direction == YAxis;
            bool horizontalFold = direction == XAxis;

            if (verticalFold)
            {
                _height = foldLine;
            }
            else
            {
                _width = foldLine;
            }

            foreach ((int x, int y) in _points)
            {
                if (verticalFold && y > foldLine)
                {
                    int diff = y - foldLine;
                    newPoints.Add((x, foldLine - diff));
                    deadPoints.Add((x, y));
                }
                else if (horizontalFold && x > foldLine)
                {
                    int diff = x - foldLine;
                    newPoints.Add((foldLine - diff, y));
                    deadPoints.Add((x, y));
                }
            }

            foreach (var point in newPoints)
            {
                if (!_points.Contains(point))
                {
                    _points.Add(point);
                }
            }

            foreach (var point in deadPoints)
            {
                _points.Remove(point);
            }
        }

        private void DrawPoints()
        {
            for (int y = 0; y < _height; y++) 
            {
                for (int x = 0; x < _width; x++)
                {
                    bool hasPoint = _points.Contains((x, y));
                    Console.Write(hasPoint ? '#' : ' ');
                }
                Console.WriteLine();
            }
        }
    }
}
