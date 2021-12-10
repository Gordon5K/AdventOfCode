using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC
{
    class Day8
    {
        readonly string _input = @"rect 1x1
rotate row y=0 by 6
rect 1x1
rotate row y=0 by 3
rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 4
rect 2x1
rotate row y=0 by 5
rect 2x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 5
rect 4x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 3
rect 1x1
rotate row y=0 by 3
rect 1x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 6
rect 4x1
rotate row y=0 by 4
rotate column x=0 by 1
rect 3x1
rotate row y=0 by 6
rotate column x=0 by 1
rect 4x1
rotate column x=10 by 1
rotate row y=2 by 16
rotate row y=0 by 8
rotate column x=5 by 1
rotate column x=0 by 1
rect 7x1
rotate column x=37 by 1
rotate column x=21 by 2
rotate column x=15 by 1
rotate column x=11 by 2
rotate row y=2 by 39
rotate row y=0 by 36
rotate column x=33 by 2
rotate column x=32 by 1
rotate column x=28 by 2
rotate column x=27 by 1
rotate column x=25 by 1
rotate column x=22 by 1
rotate column x=21 by 2
rotate column x=20 by 3
rotate column x=18 by 1
rotate column x=15 by 2
rotate column x=12 by 1
rotate column x=10 by 1
rotate column x=6 by 2
rotate column x=5 by 1
rotate column x=2 by 1
rotate column x=0 by 1
rect 35x1
rotate column x=45 by 1
rotate row y=1 by 28
rotate column x=38 by 2
rotate column x=33 by 1
rotate column x=28 by 1
rotate column x=23 by 1
rotate column x=18 by 1
rotate column x=13 by 2
rotate column x=8 by 1
rotate column x=3 by 1
rotate row y=3 by 2
rotate row y=2 by 2
rotate row y=1 by 5
rotate row y=0 by 1
rect 1x5
rotate column x=43 by 1
rotate column x=31 by 1
rotate row y=4 by 35
rotate row y=3 by 20
rotate row y=1 by 27
rotate row y=0 by 20
rotate column x=17 by 1
rotate column x=15 by 1
rotate column x=12 by 1
rotate column x=11 by 2
rotate column x=10 by 1
rotate column x=8 by 1
rotate column x=7 by 1
rotate column x=5 by 1
rotate column x=3 by 2
rotate column x=2 by 1
rotate column x=0 by 1
rect 19x1
rotate column x=20 by 3
rotate column x=14 by 1
rotate column x=9 by 1
rotate row y=4 by 15
rotate row y=3 by 13
rotate row y=2 by 15
rotate row y=1 by 18
rotate row y=0 by 15
rotate column x=13 by 1
rotate column x=12 by 1
rotate column x=11 by 3
rotate column x=10 by 1
rotate column x=8 by 1
rotate column x=7 by 1
rotate column x=6 by 1
rotate column x=5 by 1
rotate column x=3 by 2
rotate column x=2 by 1
rotate column x=1 by 1
rotate column x=0 by 1
rect 14x1
rotate row y=3 by 47
rotate column x=19 by 3
rotate column x=9 by 3
rotate column x=4 by 3
rotate row y=5 by 5
rotate row y=4 by 5
rotate row y=3 by 8
rotate row y=1 by 5
rotate column x=3 by 2
rotate column x=2 by 3
rotate column x=1 by 2
rotate column x=0 by 2
rect 4x2
rotate column x=35 by 5
rotate column x=20 by 3
rotate column x=10 by 5
rotate column x=3 by 2
rotate row y=5 by 20
rotate row y=3 by 30
rotate row y=2 by 45
rotate row y=1 by 30
rotate column x=48 by 5
rotate column x=47 by 5
rotate column x=46 by 3
rotate column x=45 by 4
rotate column x=43 by 5
rotate column x=42 by 5
rotate column x=41 by 5
rotate column x=38 by 1
rotate column x=37 by 5
rotate column x=36 by 5
rotate column x=35 by 1
rotate column x=33 by 1
rotate column x=32 by 5
rotate column x=31 by 5
rotate column x=28 by 5
rotate column x=27 by 5
rotate column x=26 by 5
rotate column x=17 by 5
rotate column x=16 by 5
rotate column x=15 by 4
rotate column x=13 by 1
rotate column x=12 by 5
rotate column x=11 by 5
rotate column x=10 by 1
rotate column x=8 by 1
rotate column x=2 by 5
rotate column x=1 by 5";

        readonly bool[][] _screen = new bool[6][];
        int _lit = 0;

        public object Task1()
        {
            for (int row = 0; row < 6; row++)
            {
                _screen[row] = new bool[50];
            }
            WriteGrid("Init");

            string[] lines = _input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for(int l = 0; l < lines.Length; l++)
            {
                string line = lines[l];

                Regex rect = new("rect ([0-9]*)x([0-9]*)");
                var matches = rect.Matches(line);
                if(matches.Count == 1)
                {
                    var match = matches[0];
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);

                    for(int iY = 0; iY < y; iY++)
                    {
                        for (int iX = 0; iX < x; iX++)
                        {
                            _screen[iY][iX] = true;
                        }
                    }
                }
                else
                {
                    Regex rotate = new("rotate (row y|column x)=([0-9]*) by ([0-9]*)");

                    matches = rotate.Matches(line);

                    if (matches.Count == 1)
                    {
                        var match = matches[0];
                        string axis = match.Groups[1].Value;
                        int index = int.Parse(match.Groups[2].Value);
                        int step = int.Parse(match.Groups[3].Value);

                        if (axis == "column x")
                        {
                            for (int s = 0; s < step; s++)
                            {
                                bool prev = _screen[^1][index];
                                for (int iY = 0; iY < _screen.Length; iY++)
                                {
                                    bool tempPrev = _screen[iY][index];
                                    _screen[iY][index] = prev;
                                    prev = tempPrev;
                                }
                            }
                        }
                        else if (axis == "row y")
                        {
                            for (int s = 0; s < step; s++)
                            {
                                bool[] row = _screen[index];
                                bool prev = row[^1];
                                for (int iX = 0; iX < row.Length; iX++)
                                {
                                    bool tempPrev = row[iX];
                                    row[iX] = prev;
                                    prev = tempPrev;
                                }
                            }
                        }
                    }
                }

                WriteGrid(line);
            }
            return "Lit: " + _lit;
        }

        void WriteGrid(string step)
        {
            Console.WriteLine(step);
            _lit = 0;
            for (int iY = 0; iY < _screen.Length; iY++)
            {
                StringBuilder line = new();
                for (int iX = 0; iX < _screen[iY].Length; iX++)
                {
                    _lit += _screen[iY][iX] ? 1 : 0;
                    line.Append(_screen[iY][iX] ? "x" : " ");
                }
                Console.WriteLine(line.ToString());
            }
        }

        private const string Message = "Read the above print";
        public static object Task2() => Message;

    }
}
