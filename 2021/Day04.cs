using System.Collections.Generic;
using System.Linq;

namespace AOC._2021
{
    class Day04 : TestClass, ITestClass
    {
        private readonly string[] _numbers;
        private const int GridSize = 5;

        private readonly Dictionary<int, string[]> _grids = new();
        private readonly Dictionary<string, List<(int, int)>> _values = new();


        public Day04()
        {
            _input = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

            string[] lines = _input.Split("\r\n\r\n");
            _numbers = lines[0].Split(',');

            for(int i = 1; i < lines.Length; i++)
            {
                string[] gridValues = new string[GridSize*GridSize];

                string gridRaw = lines[i];
                var rows = gridRaw.Split("\r\n");

                int index = 0;
                foreach(var row in rows)
                {
                    string[] rowValues = row.Split(' ', System.StringSplitOptions.RemoveEmptyEntries); 
                    foreach(var col in rowValues)
                    {
                        gridValues[index] = col;

                        if (!_values.TryGetValue(col, out List<(int, int)> colValues))
                        {
                            colValues = new List<(int, int)>();
                            _values.Add(col, colValues);
                        }
                        colValues.Add((i, index));

                        index++;
                    }
                }

                _grids.Add(i, gridValues);
            }
        }

        public object Task1()
        {
            int foundGrid = 0;
            int callIndex = 0;
            string call = null;
            while (foundGrid == 0)
            {
                call = _numbers[callIndex++];
                if(_values.TryGetValue(call, out List<(int, int)> callValues))
                {
                    foreach((int gridId, int index) in callValues)
                    {
                        var grid = _grids[gridId];
                        grid[index] = null;

                        if(TryCheckRowAndColumn(index, grid))
                        {
                            foundGrid = gridId;
                            break;
                        }
                    }
                }
            }

            int unmarkedSum = _grids[foundGrid]
                .Where(x=>x != null)
                .Sum(x => int.Parse(x));

            return unmarkedSum * int.Parse(call);
        }

        public object Task2()
        {
            int foundGrid = 0;
            int callIndex = 0;
            string call = null;

            HashSet<int> completedGrids = new();

            while (foundGrid == 0)
            {
                call = _numbers[callIndex++];
                if (_values.TryGetValue(call, out List<(int, int)> callValues))
                {
                    foreach ((int gridId, int index) in callValues)
                    {
                        if (completedGrids.Contains(gridId))
                        {
                            continue;
                        }

                        var grid = _grids[gridId];
                        grid[index] = null;

                        if (TryCheckRowAndColumn(index, grid))
                        {
                            completedGrids.Add(gridId);

                            if (completedGrids.Count == _grids.Count)
                            {
                                foundGrid = gridId;
                                break;
                            }
                        }
                    }
                }
            }

            int unmarkedSum = _grids[foundGrid]
                .Where(x => x != null)
                .Sum(x => int.Parse(x));

            return unmarkedSum * int.Parse(call);
        }

        private static bool TryCheckRowAndColumn(int index, string[] grid)
        {
            int iCol = index % GridSize;
            int iRow = index - iCol;
            int counter = 0;

            bool countingRow = true;
            bool countingCol = true;

            while (counter < GridSize)
            {
                if (countingCol && grid[iCol] != null)
                {
                    countingCol = false;
                }
                if (countingRow && grid[iRow] != null)
                {
                    countingRow = false;
                }
                iCol += GridSize;
                iRow++;
                counter++;
            }
            return countingRow || countingCol;
        }

    }
}
