using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC._2021
{
    class Day07 : TestClass, ITestClass
    {
        private readonly int[] _readings;
        public Day07()
        {
            _input = @"16,1,2,0,4,2,7,1,2,14";
            var readings = GetCommaDelimitedValues().Select(x => int.Parse(x))
                                                    .ToList();

            readings.Sort();
            _readings = readings.ToArray();
        }

        public object Task1()
        {
            int min = 0;
            for(int i = 0; i < _readings.Length; i++)
            {
                if(i > 0 && _readings[i] == _readings[i - 1])
                {
                    continue;
                }

                int target = _readings[i];
                int cur = 0;
                bool better = true;
                for(int x = 0; x < _readings.Length; x++)
                {
                    int diff = Math.Abs(_readings[x] - target);
                    cur += diff;

                    if(min > 0 && cur > min)
                    {
                        better = false;
                        break;
                    }
                }

                if (better)
                {
                    min = cur;
                }
            }

            return min;
        }

        public object Task2()
        {
            (int minIndex, _) = FindMin(_readings, _readings);

            int midPoint = _readings[minIndex];

            List<int> subSearch = new();
            if(minIndex > 0)
            {
                int scrollTo = _readings[minIndex - 1] + 1;
                for(int i = scrollTo; i <= midPoint; i++)
                {
                    subSearch.Add(i);
                }
            }

            if(minIndex < _readings.Length - 1)
            {
                int scrollTo = _readings[minIndex + 1];
                for (int i = midPoint + 1; i < scrollTo; i++)
                {
                    subSearch.Add(i);
                }
            }

            (_, int min) = FindMin(subSearch.ToArray(), _readings);

            return min;
        }

        private static (int minIndex, int min) FindMin(int[] targets, int[] readings)
        {
            int minIndex = 0;
            int min = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (i > 0 && targets[i] == targets[i - 1])
                {
                    continue;
                }

                int target = targets[i];
                int cur = 0;
                bool better = true;
                for (int x = 0; x < readings.Length; x++)
                {
                    int diff = Math.Abs(readings[x] - target);
                    int diffExp = 0;
                    for (int y = 0; y < diff; y++)
                    {
                        diffExp += (y + 1);
                    }

                    cur += diffExp;

                    if (min > 0 && cur > min)
                    {
                        better = false;
                        break;
                    }
                }

                if (better)
                {
                    minIndex = i;
                    min = cur;
                }
            }

            return (minIndex, min);
        }
    }
}
