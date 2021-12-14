using System.Collections.Generic;

namespace AOC._2021
{
    class Day14 : TestClass, ITestClass
    {
        private List<char> _template; //Part 1
        private Dictionary<string, long> _pairs; //Part 2
        private Dictionary<string, char> _rules;
        private Dictionary<char, long> _counts;

        public Day14()
        {
            _input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";
            
        }

        private void ParseInputPart1()
        {
            _template = new();
            _rules = new();
            _counts = new();

            string[] lines = GetVerticalSplitLines();

            foreach(char c in lines[0])
            {
                _template.Add(c);
                IncrementCharCount(c);
            }

            ReadRules(lines);
        }

        private void ParseInputPart2()
        {
            _pairs = new();
            _rules = new();
            _counts = new();

            string[] lines = GetVerticalSplitLines();

            for (int i = 0; i < lines[0].Length - 1; i++)
            {
                IncrementCharCount(lines[0][i]);

                string pair = new(new char[] { lines[0][i], lines[0][i + 1] });
                if (!_pairs.ContainsKey(pair))
                {
                    _pairs.Add(pair, 1);
                }
                else
                {
                    _pairs[pair]++;
                }
            }

            IncrementCharCount(lines[0][^1]);

            ReadRules(lines);
        }

        private void ReadRules(string[] lines)
        {
            for (int i = 2; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(" -> ");

                _rules.Add(parts[0], parts[1][0]);
            }
        }

        public object Task1()
        {
            //Via brute force with insertion

            ParseInputPart1();

            int stepCount = 0;
            int steps = 10;

            while (stepCount++ < steps)
            {
                int cur = 0;
                while (cur < _template.Count - 1)
                {
                    string pair = new(new char[] { _template[cur], _template[cur + 1] });
                    if (_rules.TryGetValue(pair, out char newChar))
                    {
                        _template.Insert(cur + 1, newChar);
                        IncrementCharCount(newChar);
                        cur += 2;
                    }
                }
            }

            return GetAnswer();
        }

        public object Task2()
        {
            //Using a dictionary of pairs, split each pair and ammend with the new character to create new pairs

            ParseInputPart2();

            int stepCount = 0;
            int steps = 40;

            while (stepCount++ < steps)
            {
                Dictionary<string, long> newPairs = new();

                foreach ((string pair, long count) in _pairs)
                {
                    if (count <= 0) continue;

                    if (_rules.TryGetValue(pair, out char newChar))
                    {
                        IncrementCharCount(newChar, count);

                        string newPair1 = new(new char[] { pair[0], newChar });
                        string newPair2 = new(new char[] { newChar, pair[1] });

                        //Add the new pairs
                        IncrementDictionaryCount(newPairs, newPair1, count);
                        IncrementDictionaryCount(newPairs, newPair2, count);

                        //Remove the old pair as it's been split
                        IncrementDictionaryCount(newPairs, pair, count: -count);
                    }
                }

                foreach ((string pairKey, long count) in newPairs)
                {
                    IncrementDictionaryCount(_pairs, pairKey, count);
                }
            }

            return GetAnswer();
        }

        private long GetAnswer()
        {
            long minCount = long.MaxValue, maxCount = 0;
            foreach (var counts in _counts.Values)
            {
                if (counts <= 0) continue;

                if (counts < minCount)
                {
                    minCount = counts;
                }
                if (counts > maxCount)
                {
                    maxCount = counts;
                }
            }

            return maxCount - minCount;
        }

        private void IncrementCharCount(char c, long count = 1) => IncrementDictionaryCount(_counts, c, count);

        private static void IncrementDictionaryCount<T>(Dictionary<T, long> counters, T key, long count = 1)
        {
            if (!counters.ContainsKey(key))
            {
                counters.Add(key, count);
            }
            else
            {
                counters[key] += count;
            }
        }
    }
}
