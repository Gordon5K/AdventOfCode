namespace AOC._2021
{
    class Day01 : TestClass, ITestClass
    {
        private readonly string[] _readings;
        public Day01()
        {
            _input = @"199
200
208
210
200
207
240
269
260
263";
            _readings = GetVerticalSplitLines();
        }

        public object Task1()
        {
            string[] readings = GetVerticalSplitLines();

            int counter = 0;
            for(int i = 1; i < readings.Length; i++)
            {
                if(int.Parse(readings[i]) > int.Parse(readings[i - 1]))
                {
                    counter++;
                }
            }

            return counter;
        }

        public object Task2()
        {
            int counter = 0;
            int[] points = new int[4];

            for (int i = 0; i < _readings.Length; i++)
            {
                points[0] = points[1];
                points[1] = points[2];
                points[2] = points[3];

                points[3] = int.Parse(_readings[i]);

                if(i > 2 && points[0] < points[3])
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
