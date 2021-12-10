using System.Collections.Generic;

namespace AOC._2021
{
    class Day10 : TestClass, ITestClass
    {
        private readonly string[] _readings;
        private readonly Dictionary<char, char> _closureMap = new()
        {
            ['['] = ']',
            ['('] = ')',
            ['{'] = '}',
            ['<'] = '>',
        };

        private readonly Dictionary<char, int> _syntaxCharacterScores = new()
        {
            [']'] = 57,
            [')'] = 3,
            ['}'] = 1197,
            ['>'] = 25137,
        };

        private readonly Dictionary<char, int> _autoCompleteCharacterScores = new()
        {
            ['['] = 2,
            ['('] = 1,
            ['{'] = 3,
            ['<'] = 4,
        };

        public Day10()
        {
            _input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";
            _readings = GetVerticalSplitLines();
        }

        public object Task1()
        {
            var openings = new Stack<char>();

            int scoreTotal = 0;
            foreach(string line in _readings)
            {
                openings.Clear();
                int syntaxScore = 0;

                foreach(char c in line)
                {
                    if (_closureMap.ContainsKey(c))
                    {
                        openings.Push(c);
                    }
                    else if (openings.Count > 0 && c == _closureMap[openings.Peek()])
                    {
                        openings.Pop();
                    }
                    else
                    {
                        syntaxScore = _syntaxCharacterScores[c];
                        break;
                    }
                }
                scoreTotal += syntaxScore;
            }

            return scoreTotal;
        }

        public object Task2()
        {
            var openings = new Stack<char>();

            List<long> scores = new();

            foreach (string line in _readings)
            {
                openings.Clear();
                bool isValid = true;

                foreach (char c in line)
                {
                    if (_closureMap.ContainsKey(c))
                    {
                        openings.Push(c);
                    }
                    else if (openings.Count > 0 && c == _closureMap[openings.Peek()])
                    {
                        openings.Pop();
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
                
                if(isValid && openings.Count > 0)
                {
                    //There is an incomplete line
                    long score = 0;

                    while(openings.Count > 0)
                    {
                        char c = openings.Pop();
                        score *= 5;
                        score += _autoCompleteCharacterScores[c];
                    }

                    scores.Add(score);
                }
            }

            scores.Sort();

            return scores[scores.Count / 2];
        }
    }
}
