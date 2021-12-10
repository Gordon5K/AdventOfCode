using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC._2018
{
    class Day6
    {
        //readonly string _input = @"1, 1
        //1, 6
        //8, 3
        //3, 4
        //5, 5
        //8, 9"

        readonly string _input = @"61, 90
        199, 205
        170, 60
        235, 312
        121, 290
        62, 191
        289, 130
        131, 188
        259, 82
        177, 97
        205, 47
        302, 247
        94, 355
        340, 75
        315, 128
        337, 351
        73, 244
        273, 103
        306, 239
        261, 198
        355, 94
        322, 69
        308, 333
        123, 63
        218, 44
        278, 288
        172, 202
        286, 172
        141, 193
        72, 316
        84, 121
        106, 46
        349, 77
        358, 66
        309, 234
        289, 268
        173, 154
        338, 57
        316, 95
        300, 279
        95, 285
        68, 201
        77, 117
        313, 297
        259, 97
        270, 318
        338, 149
        273, 120
        229, 262
        270, 136";

        List<Coordinate> _values;

        private string[] GetLines()
        {
            var lines = _input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }

        private void GetValues()
        {
            _values = new List<Coordinate>();

            var lines = GetLines();
            Regex r = new(@"(\d+), (\d+)");

            foreach(var line in lines)
            {
                Match m = r.Match(line);
                _values.Add(new Coordinate(int.Parse(m.Groups[1].ToString()), int.Parse(m.Groups[2].ToString())));
            }
        }

        public string Task1()
        {
            GetValues();

            int x0 = int.MaxValue, xn = 0, y0 = int.MaxValue, yn = 0;

            foreach(var value in _values)
            {
                if (value.X < x0) x0 = value.X;
                if (value.X > xn) xn = value.X;
                if (value.Y < y0) y0 = value.Y;
                if (value.Y > yn) yn = value.Y;
            }

            foreach(var value in _values)
            {
                if (value.X <= x0 || value.X >= xn || value.Y <= y0 || value.Y > yn)
                {
                    value.IsInfinite = true;
                }
            }

            for(int x = x0; x < xn; x++)
            {
                for(int y = y0; y < yn; y++)
                {
                    int closestZ = int.MaxValue;
                    foreach(var value in _values)
                    {
                        int z = value.Distance(x, y);
                        if (z < closestZ)
                        {
                            closestZ = z;
                        }
                    }

                    var allClosest = _values.Where(s => s.Distance(x,y) == closestZ);
                    if (allClosest.Count() != 1)
                    {
                        continue;
                    }

                    var closest = allClosest.First();

                    closest.ClosestCount++;
                }
            }

            var nonInfinite = _values.Where(s => !s.IsInfinite);
            var largestArea = nonInfinite.Max(s => s.ClosestCount);

            return largestArea.ToString();
        }

        public string Task2()
        {
            GetValues();

            int x0 = int.MaxValue, xn = 0, y0 = int.MaxValue, yn = 0;

            foreach (var value in _values)
            {
                if (value.X < x0) x0 = value.X;
                if (value.X > xn) xn = value.X;
                if (value.Y < y0) y0 = value.Y;
                if (value.Y > yn) yn = value.Y;
            }

            int safeRegion = 0;

            for (int x = x0; x < xn; x++)
            {
                for (int y = y0; y < yn; y++)
                {
                    int sumDistance = 0;
                    foreach (var value in _values)
                    {
                        sumDistance += value.Distance(x, y);
                    }

                    if(sumDistance < 10000)
                    {
                        safeRegion++;
                    }
                }
            }

            return safeRegion.ToString();
        }

        private sealed class Coordinate
        {
            public int X;
            public int Y;
            public bool IsInfinite = false;
            public int ClosestCount = 0;

            public int Distance(int x, int y)
            {
                int zX = X > x ? X - x : x - X;
                int zY = Y > y ? Y - y : y - Y;
                return zX + zY;
            }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
