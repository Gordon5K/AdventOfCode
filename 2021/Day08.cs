using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC._2021
{
    class Day08 : TestClass, ITestClass
    {
        private readonly string[] _readings;

        public Day08()
        {
            _input = @"acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf
be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce";
            _readings = GetVerticalSplitLines();
        }

        public object Task1()
        {
            int counter = 0;
            foreach(string reading in _readings)
            {
                var map = new Dictionary<int, string>();

                (string[] values, string[] outputs) = GetSegments(reading);

                foreach (string value in outputs)
                {
                    int num = value.Length switch
                    {
                        2 => 1,
                        3 => 7,
                        4 => 4,
                        7 => 8,
                        _ => -1
                    };

                    if (num != -1)
                    {
                        if (map.ContainsKey(value.Length))
                        {
                            map.Add(num, value);
                        }
                        counter++;
                    }
                }
            }

            return counter;
        }

        public object Task2()
        {
            int total = 0;

            foreach (string reading in _readings)
            {
                var valueMap = new SortedDictionary<int, string>();
                var keys = new HashSet<string>();

                (string[] values, string[] outputs) = GetSegments(reading);

                foreach (string value in values)
                {
                    string sortedValue = value;
                    if (!keys.Add(sortedValue))
                    {
                        continue;
                    }

                    int num = value.Length switch
                    {
                        2 => 1,
                        3 => 7,
                        4 => 4,
                        7 => 8,
                        _ => -1
                    };

                    if (num != -1)
                    {
                        valueMap.Add(num, value);
                    }
                }

                char top, 
                    middle, 
                    bottom, 
                    tRight = '\0', 
                    bRight = '\0', 
                    tLeft, 
                    bLeft;

                var oneChars = GetChars(valueMap[1]);
                var fourChars = GetChars(valueMap[4]);
                var sevenChars = GetChars(valueMap[7]);
                var eightChars = GetChars(valueMap[8]);

                //Find top
                top = sevenChars.Except(fourChars).First();

                //Top right should appear in eight values. Bottom right in 9
                foreach(char c in oneChars)
                {
                    int matchCount = keys.Count(x => x.Contains(c));
                    if(matchCount == 8)
                    {
                        tRight = c;
                    }
                    else
                    {
                        bRight = c;
                    }
                }

                //3 should contain five chars && both of the one chars
                string three = keys.First(x => x.Length == 5 && x.Contains(tRight) && x.Contains(bRight));
                valueMap.Add(3, three);

                //9 should contain 6 chars && contain all of the three chars
                string nine = keys.First(x => x.Length == 6 && three.All(y => x.Contains(y)));
                valueMap.Add(9, nine);

                //Top left is the difference between three and nine
                tLeft = nine.Except(three).First();

                //middle is four minus top left, top right, bottom right
                middle = fourChars.Except(new char[] { tLeft, tRight, bRight }).First();

                //bottom is the unknown char from nine
                bottom = nine.Except(new char[] { tLeft, tRight, bRight, top, middle }).First();

                //Bottom left is the last unknown
                bLeft = eightChars.Except(new char[] { tLeft, tRight, bRight, top, middle, bottom }).First();


                //Find numbers
                string zero = keys
                    .First(x => x.Length == 6 && new char[] { 
                        top, tRight, bRight, bottom, bLeft, tLeft
                    }
                    .All(y => x.Contains(y)));

                string two = keys
                    .First(x => x.Length == 5 && new char[] {
                        top, tRight, middle, bLeft, bottom
                    }
                    .All(y => x.Contains(y)));

                string five = keys.First(x => x.Length == 5 && x != two && x != three);

                string six = keys.First(x => x.Length == 6 && x != zero && x != nine);

                valueMap.Add(0, zero);
                valueMap.Add(2, two);
                valueMap.Add(5, five);
                valueMap.Add(6, six);

                var reverseMap = valueMap.ToDictionary(x => GetSortedString(x.Value), x => x.Key);

                var stringBuilder = new StringBuilder();
                foreach (string value in outputs)
                {
                    reverseMap.TryGetValue(GetSortedString(value), out int num);
                    stringBuilder.Append(num);
                }

                total += int.Parse(stringBuilder.ToString());
            }

            return total;
        }


        private static (string[] values, string[] outputs) GetSegments(string reading)
        {
            string[] parts = reading.Split(" | ");
            string[] values = GetSpaceDelimitedValues(parts[0]);
            string[] outputs = GetSpaceDelimitedValues(parts[1]);

            return (values, outputs);
        }


        private static string GetSortedString(string value)
        {
            var stringBuilder = new StringBuilder();

            var sortedChars = new SortedSet<char>(value);
            foreach (char c in sortedChars)
            {
                stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }

        private static SortedSet<char> GetChars(string value) => new(value);

    }
}
