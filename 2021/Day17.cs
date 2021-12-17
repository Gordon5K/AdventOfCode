using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC._2021
{
    class Day17 : TestClass, ITestClass
    {
        record TargetBounds(int X0, int X1, int Y0, int Y1);

        private readonly TargetBounds _target;

        public Day17()
        {
            _input = @"target area: x=20..30, y=-10..-5";

            MatchCollection bounds = Regex.Matches(_input, pattern: @"(-?\d+)");
            _target = new TargetBounds(
                X0: int.Parse(bounds[0].ToString()),
                X1: int.Parse(bounds[1].ToString()),
                Y0: int.Parse(bounds[3].ToString()),
                Y1: int.Parse(bounds[2].ToString()));
        }

        public object Task1()
        {
            int maxY = -_target.Y1;
            int maxYVelocity = maxY - 1;

            int maxHeight = (maxYVelocity * (maxYVelocity + 1)) / 2;

            return maxHeight;
        }

        public object Task2()
        {
            int minYVelocity = _target.Y1;
            int maxYVelocity = -_target.Y1;

            int minXVelocity = (int)Math.Ceiling((Math.Sqrt(1 + (8 * _target.X0)) - 1) / 2);
            int maxXVelocity = _target.X1;

            Dictionary<int, HashSet<int>> ySteps = new();
            for (int y = minYVelocity; y <= maxYVelocity; y++)
            {
                int t = 1;
                int vY = y;
                int s = vY;
                while (s >= _target.Y1)
                {
                    if (s <= _target.Y0)
                    {
                        if (!ySteps.TryGetValue(t, out HashSet<int> velocities))
                        {
                            velocities = new() { y };
                            ySteps.Add(t, velocities);
                        }
                        else
                        {
                            velocities.Add(y);
                        }
                    }

                    vY--;
                    s += vY;
                    t++;
                }
            }

            int maxSteps = ySteps.Keys.Max();
            HashSet<(int x, int y)> points = new();
            for (int x = minXVelocity; x <= maxXVelocity; x++)
            {
                int t = 1;
                int vX = x;
                int s = vX;
                while (t <= maxSteps && s <= _target.X1)
                {
                    if (s >= _target.X0 && ySteps.TryGetValue(t, out HashSet<int> velocities))
                    {
                        foreach(int y in velocities)
                        {
                            points.Add((x, y));
                        }
                    }

                    if(vX > 0) vX--;
                    s += vX;
                    t++;
                }
            }

            return points.Count;
        }
    }
}
