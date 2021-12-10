using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC
{
    class Day9
    {
        readonly string _input = @"X(8x2)(3x3)ABCY";

        public object Task1()
        {

            string result = Expand(_input);
            return result.Length;
        }

        readonly Regex _regex = new(@"\((?<count>\d*)x(?<repeat>\d*)\)(?<data>[()\dxA-Z]*)");

        string Expand(string input)
        {
            StringBuilder result = new();
            int firstMatch = input.Length;
            var match = _regex.Match(input);
            if(match.Success)
            { 
                firstMatch = match.Index;

                int count = int.Parse(match.Groups["count"].Value);
                int repeat = int.Parse(match.Groups["repeat"].Value);

                string data = match.Groups["data"].Value;

                var expandPart = data.Substring(0, count);
                for (int i = 0; i < repeat; i++)
                {
                    result.Append(expandPart);
                }

                result.Append(Expand(data[count..]));
            }
            result.Clear();
            result.Append(input.Substring(0, firstMatch) + result).Replace(" ", string.Empty);
            return result.ToString();
        }

        public object Task2()
        {
            string result = _input;
            while(_regex.IsMatch(result))
            {
                result = Expand(result);
            }

            return result.Length;
        }

    }
}
