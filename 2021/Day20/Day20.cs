using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AOC._2021
{
    class Day20 : TestClass, ITestClass
    {
        record Coord (int X, int Y)
        {
            public IEnumerable<Coord> Neighbours()
            {
                for (int y = Y - 1; y < Y + 2; y++)
                {
                    for (int x = X - 1; x < X + 2; x++)
                    {
                        yield return new Coord(x, y);
                    }
                }
            }
        }

        record Grid(int X, int Y) : Coord(X, Y)
        {
            public Grid Expand() => new (X + 2, Y + 2);
        }

        private readonly bool[] _transformAlg;
        private HashSet<Coord> _image = new();
        
        private Grid _size;
        private readonly bool _willFlash;
        private bool _infiniteValue = false;

        public Day20()
        {
            _input = ReadInputFile(useDemo: false);

            string[] lines = GetVerticalSplitLines();

            _transformAlg = new bool[512];
            for(int i = 0; i < lines[0].Length; i++)
            {
                _transformAlg[i] = lines[0][i] == '#';
            }

            for(int y = 2; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (lines[y][x] == '#')
                    {
                        _image.Add(new Coord(x, y - 2));
                    }
                }
            }

            _size = new Grid(lines[2].Length, lines.Length - 2);
            _willFlash = _transformAlg[0];
        }

        public object Task1()
        {
            Expand(steps: 2);

            return _image.Count;
        }

        public object Task2()
        {
            Expand(steps: 48);

            return _image.Count;
        }

        private void Expand(int steps)
        {
            while(steps-- > 0)
            {
                Expand();
            }
        }

        private void Expand()
        {
            HashSet<Coord> newImage = new();

            int y = -1;
            int x;

            while (y < _size.Y + 2)
            {
                x = -1;

                while (x < _size.X + 2)
                {
                    int sum = NeighbourSum(new Coord(x, y));
                    if (_transformAlg[sum])
                    {
                        newImage.Add(new(x + 1, y + 1));
                    }

                    x++;
                }
                y++;
            }

            if (_willFlash)
            {
                _infiniteValue = !_infiniteValue;
            }

            _image = newImage;
            _size = _size.Expand();
        }

        private int NeighbourSum(Coord centre)
        {
            int sum = 0;
            foreach(Coord coord in centre.Neighbours())
            {
                sum <<= 1;
                if (_image.Contains(coord))
                {
                    sum ++;
                }
                else
                {
                    bool outOfBounds = coord.X < 0 || coord.Y < 0 || coord.X > _size.X || coord.Y > _size.Y;
                    if(outOfBounds && _infiniteValue)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
    }
}
