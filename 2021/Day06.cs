using System.Collections.Generic;
using System.Linq;

namespace AOC._2021
{
    class Day06 : TestClass, ITestClass
    {
        private readonly string[] _readings;
        private const int MaxDays = 7;
        private const int AdditionalNewDays = 2;

        public Day06()
        {
            _input = @"3,4,3,1,2";
            _readings = GetCommaDelimitedValues();
        }

        public object Task1()
        {
            var counters = new SortedDictionary<int, int>();
            int range = MaxDays + AdditionalNewDays;
            for (int i = 0; i < range; i++)
            {
                counters.Add(i, 0);
            }

            foreach(string reading in _readings)
            {
                int counter = int.Parse(reading);
                counters[counter]++;
            }

            int ticks = 18;
            for(int i = 0; i < ticks; i++)
            {
                int toSpawn = counters[0];
                for(int c = 0; c < counters.Count - 1; c++)
                {
                    counters[c] = counters[c + 1];
                }

                counters[MaxDays - 1] += toSpawn;
                counters[counters.Count - 1] = toSpawn;
            }

            return counters.Sum(x => x.Value);
        }

        public object Task2()
        {
            var counters = new SortedDictionary<int, long>();
            int range = MaxDays + AdditionalNewDays;
            for (int i = 0; i < range; i++)
            {
                counters.Add(i, 0);
            }

            foreach (string reading in _readings)
            {
                int counter = int.Parse(reading);
                counters[counter]++;
            }

            int ticks = 256;
            for (int i = 0; i < ticks; i++)
            {
                long toSpawn = counters[0];
                for (int c = 0; c < counters.Count - 1; c++)
                {
                    counters[c] = counters[c + 1];
                }

                counters[MaxDays - 1] += toSpawn;
                counters[counters.Count - 1] = toSpawn;
            }
            
            return counters.Sum(x => x.Value);
        }
    }
}
