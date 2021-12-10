using System;

namespace AOC._2018
{
    class Template
    {
        readonly string _input = @"";

        private string[] GetLines()
        {
            var lines = _input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }
       
        private void GetValues()
        {
            _ = GetLines();
        }

        public string Task1()
        {
            GetValues();
            return "";
        }

        public string Task2() => Task1();
    }
}
