using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC._2021
{
    class Day03 : TestClass, ITestClass
    {
        private readonly string[] _readings;
        private readonly int _bitLength;

        public Day03()
        {
            _input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
            _readings = GetVerticalSplitLines();
            _bitLength = _readings[0].Length;
        }

        public object Task1()
        {
            int midPoint = _readings.Length / 2;

            int[] bitSum = new int[_bitLength];

            foreach(string reading in _readings)
            {
                for(int i = 0; i < _bitLength; i++)
                {
                    bitSum[i] += (reading[i] == '1' ? 1 : 0);
                }
            }

            int gamma = 0, eps = 0;
            for(int i = 0; i < _bitLength; i++)
            {
                gamma <<= 1;
                eps <<= 1;
                if(bitSum[i] > midPoint)
                {
                    gamma += 1;
                }
                else
                {
                    eps += 1;
                }
            }

            return gamma * eps;
        }

        public object Task2()
        {
            ReadColumn(_readings, 0, out List<string> ones, out List<string> zeros);

            string oReading, cReading;

            if (ones.Count >= zeros.Count)
            {
                oReading = ExtractReadings(ones.ToArray(), index: 1, direction: 1).First();
                cReading = ExtractReadings(zeros.ToArray(), index: 1, direction: -1).First();
            }
            else
            {
                oReading = ExtractReadings(zeros.ToArray(), index: 1, direction: 1).First();
                cReading = ExtractReadings(ones.ToArray(), index: 1, direction: -1).First();
            }

            int oxygen = 0, co2 = 0;
            for (int i = 0; i < _bitLength; i++)
            {
                oxygen <<= 1;
                co2 <<= 1;

                oxygen += oReading[i] == '1' ? 1 : 0;
                co2 += cReading[i] == '1' ? 1 : 0;
            }

            return oxygen * co2;
        }

        private string[] ExtractReadings(string[] readings, int index, int direction = 1)
        {
            if (index == _bitLength || readings.Length == 1) return readings;

            ReadColumn(readings, index, out List<string> ones, out List<string> zeros);

            int diff = ones.Count - zeros.Count;
            if ((direction == 1 && diff >= 0) || (direction == -1 && diff < 0))
            {
                return ExtractReadings(ones.ToArray(), index + 1, direction);
            }
            else
            {
                return ExtractReadings(zeros.ToArray(), index + 1, direction);
            }
        }

        private static void ReadColumn(string[] readings, int index, out List<string> ones, out List<string> zeros)
        {
            ones = new();
            zeros = new();
            foreach (string reading in readings)
            {
                if (reading[index] == '1')
                {
                    ones.Add(reading);
                }
                else
                {
                    zeros.Add(reading);
                }
            }
        }
    }
}
