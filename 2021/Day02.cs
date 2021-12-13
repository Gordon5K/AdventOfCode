namespace AOC._2021
{
    class Day02 : TestClass, ITestClass
    {
        private readonly string[] _readings;
        public Day02()
        {
            _input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
            _readings = GetVerticalSplitLines();
        }

        public object Task1()
        {
            int x = 0, y = 0;
            foreach(string inst in _readings)
            {
                string[] parts = inst.Split(' ');
                int delta = int.Parse(parts[1]);
                switch (parts[0])
                {
                    case "forward":
                        x += delta;
                        break;
                    case "down":
                        y += delta;
                        break;
                    case "up":
                        y -= delta;
                        break;
                }
            }

            return x * y;
        }

        public object Task2()
        {
            int x = 0, y = 0, aim = 0;
            foreach (string inst in _readings)
            {
                string[] parts = inst.Split(' ');
                int delta = int.Parse(parts[1]);
                switch (parts[0])
                {
                    case "forward":
                        x += delta;
                        y += (aim * delta);
                        break;
                    case "down":
                        aim += delta;
                        break;
                    case "up":
                        aim -= delta;
                        break;
                }
            }

            return x * y;
        }
    }
}
