namespace AOC._2021
{
    internal interface ITestClass
    {
        object Task1();
        object Task2();
    } 

    internal abstract class TestClass
    {
        protected string _input;
        protected string[] GetVerticalSplitLines() => _input.Split("\r\n");
        protected string[] GetCommaDelimitedValues() => GetCommaDelimitedValues(_input);
        protected static string[] GetCommaDelimitedValues(string str) => str.Split(',');
        protected static string[] GetSpaceDelimitedValues(string str) => str.Split(' ');
    }
}
