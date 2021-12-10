using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC._2018
{
    class Day7
    {
        //        readonly string _input = @"Step C must be finished before step A can begin.
        //Step C must be finished before step F can begin.
        //Step A must be finished before step B can begin.
        //Step A must be finished before step D can begin.
        //Step B must be finished before step E can begin.
        //Step D must be finished before step E can begin.
        //Step F must be finished before step E can begin."

        readonly string _input = @"Step S must be finished before step G can begin.
        Step E must be finished before step T can begin.
        Step G must be finished before step A can begin.
        Step P must be finished before step Z can begin.
        Step L must be finished before step Z can begin.
        Step F must be finished before step H can begin.
        Step D must be finished before step Y can begin.
        Step J must be finished before step Y can begin.
        Step N must be finished before step O can begin.
        Step R must be finished before step Y can begin.
        Step Y must be finished before step W can begin.
        Step U must be finished before step T can begin.
        Step H must be finished before step W can begin.
        Step T must be finished before step Z can begin.
        Step Q must be finished before step B can begin.
        Step O must be finished before step Z can begin.
        Step K must be finished before step W can begin.
        Step M must be finished before step C can begin.
        Step A must be finished before step Z can begin.
        Step C must be finished before step X can begin.
        Step I must be finished before step V can begin.
        Step V must be finished before step W can begin.
        Step W must be finished before step X can begin.
        Step Z must be finished before step B can begin.
        Step X must be finished before step B can begin.
        Step D must be finished before step M can begin.
        Step S must be finished before step Z can begin.
        Step A must be finished before step B can begin.
        Step V must be finished before step Z can begin.
        Step Q must be finished before step Z can begin.
        Step O must be finished before step W can begin.
        Step S must be finished before step E can begin.
        Step L must be finished before step B can begin.
        Step P must be finished before step Y can begin.
        Step K must be finished before step M can begin.
        Step W must be finished before step Z can begin.
        Step Y must be finished before step Q can begin.
        Step J must be finished before step M can begin.
        Step U must be finished before step H can begin.
        Step Y must be finished before step U can begin.
        Step D must be finished before step A can begin.
        Step C must be finished before step V can begin.
        Step G must be finished before step J can begin.
        Step O must be finished before step C can begin.
        Step P must be finished before step H can begin.
        Step M must be finished before step B can begin.
        Step T must be finished before step C can begin.
        Step A must be finished before step W can begin.
        Step C must be finished before step B can begin.
        Step Q must be finished before step I can begin.
        Step O must be finished before step A can begin.
        Step N must be finished before step H can begin.
        Step Q must be finished before step C can begin.
        Step G must be finished before step W can begin.
        Step V must be finished before step X can begin.
        Step A must be finished before step V can begin.
        Step S must be finished before step C can begin.
        Step O must be finished before step M can begin.
        Step E must be finished before step L can begin.
        Step D must be finished before step V can begin.
        Step P must be finished before step N can begin.
        Step O must be finished before step I can begin.
        Step P must be finished before step K can begin.
        Step N must be finished before step A can begin.
        Step A must be finished before step X can begin.
        Step L must be finished before step A can begin.
        Step L must be finished before step T can begin.
        Step I must be finished before step X can begin.
        Step N must be finished before step C can begin.
        Step N must be finished before step W can begin.
        Step Y must be finished before step M can begin.
        Step R must be finished before step A can begin.
        Step O must be finished before step X can begin.
        Step G must be finished before step T can begin.
        Step S must be finished before step P can begin.
        Step E must be finished before step M can begin.
        Step E must be finished before step A can begin.
        Step E must be finished before step W can begin.
        Step F must be finished before step D can begin.
        Step U must be finished before step C can begin.
        Step R must be finished before step Z can begin.
        Step A must be finished before step C can begin.
        Step F must be finished before step K can begin.
        Step L must be finished before step V can begin.
        Step F must be finished before step T can begin.
        Step W must be finished before step B can begin.
        Step Y must be finished before step A can begin.
        Step D must be finished before step T can begin.
        Step S must be finished before step V can begin.
        Step Y must be finished before step O can begin.
        Step K must be finished before step B can begin.
        Step N must be finished before step V can begin.
        Step Y must be finished before step I can begin.
        Step Z must be finished before step X can begin.
        Step E must be finished before step B can begin.
        Step P must be finished before step O can begin.
        Step D must be finished before step R can begin.
        Step Q must be finished before step X can begin.
        Step E must be finished before step K can begin.
        Step J must be finished before step R can begin.
        Step L must be finished before step N can begin.";

        private string[] GetLines()
        {
            var lines = _input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }

        Dictionary<string, List<string>> _deps = new();
        Dictionary<string, int> _required = new();
        string _answer;

        private void GetValues()
        {
            _deps = new Dictionary<string, List<string>>();
            _required = new Dictionary<string, int>();
            _answer = "";

            var lines = GetLines();
            Regex r = new(@"Step (\w) must be finished before step (\w) can begin");
            foreach(var line in lines)
            {
                Match m = r.Match(line);
                string depName = m.Groups[1].ToString();
                string nextName = m.Groups[2].ToString();

                if (!_deps.ContainsKey(depName)) _deps.Add(depName, new List<string>());
                _deps[depName].Add(nextName);

                if (!_required.ContainsKey(nextName)) _required.Add(nextName, 0);
                _required[nextName]++;
            }
        }

        private string Search(string key)
        {
            _answer += key;
            if (_deps.ContainsKey(key))
            {
                foreach (var n in _deps[key].OrderBy(s=>s))
                {
                    _required[n]--;
                    if (_required[n] == 0)
                    {
                        Search(n);
                    }
                }
            }

            return _answer;
        }

        public string Task1()
        {
            GetValues();

            string answer = "";
            foreach (var d in _deps)
            {
                if (!_required.ContainsKey(d.Key))
                {
                    answer = Search(d.Key);
                }
            }

            return answer;
        }

        public string Task2()
        {
            GetValues();
            return "";
        }
    }
}
