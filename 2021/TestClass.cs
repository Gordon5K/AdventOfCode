using System;
using System.IO;

namespace AOC._2021
{
    internal interface ITestClass
    {
        object Task1();
        object Task2();
    } 

    public abstract class TestClass
    {
        protected string _input;

        protected string ReadInputFile(bool useDemo = false, int? part = null)
        {
            string partNumber = part == null || part == 1 ? "" : $".{part}";
            string fileName = useDemo ? $"input.demo{partNumber}.txt" : $"input{partNumber}.txt";

            string path = Path.Combine(Environment.CurrentDirectory, "2021", GetType().Name, fileName);
            return File.ReadAllText(path);
        }

        protected string[] GetVerticalSplitLines() => _input.Split("\r\n");
        protected string[] GetCommaDelimitedValues() => GetCommaDelimitedValues(_input);
        protected static string[] GetCommaDelimitedValues(string str) => str.Split(',');
        protected static string[] GetSpaceDelimitedValues(string str) => str.Split(' ');
    }
}
