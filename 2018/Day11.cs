using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC._2018
{
    class Day11
    {
        readonly int _serialNumber = 3613;

        readonly Dictionary<string, int> _cells = new();
        readonly Dictionary<string, int> _cellsGrid = new();
        readonly Dictionary<string, ScoreValue> _cellsGrid2 = new();

        private void GetValues()
        {
            for (int y = 1; y < 301; y++)
            {
                for (int x = 1; x < 301; x++)
                {
                    int power = GetPowerValue(x, y);
                    string key = $"{x},{y}";
                    _cells.Add(key, power);

                    if(x > 2 && y > 2)
                    {
                        GetPowerGrid3x3(x, y);
                    }

                    GetPowerGridAll(x, y);
                }
            }
        }

        private int GetPowerValue(int x, int y)
        {
            int rackId = x + 10;
            int power = rackId * y;
            power += _serialNumber;
            power *= rackId;
            if (power < 100)
            {
                power = 0;
            }
            else
            {
                power = int.Parse(power.ToString().Reverse().ElementAt(2).ToString());
            }
            power -= 5;
            return power;
        }

        private void GetPowerGrid3x3(int xn, int yn)
        {
            int x0 = xn - 2;
            int y0 = yn - 2;

            string key = $"{x0},{y0}";
            int power = 0;

            for (int x = x0; x < xn + 1; x++)
            {
                for (int y = y0; y < yn + 1; y++)
                {
                    string subKey = $"{x},{y}";
                    power += _cells[subKey];
                }
            }

            _cellsGrid.Add(key, power);
        }

        private void GetPowerGridAll(int xn, int yn)
        {
            int width = Math.Min(xn, yn);

            _cellsGrid2.Add($"{xn},{yn}", new ScoreValue());

            int adPower = 0;

            int cx = xn, cy = yn-1;
            for(int scale = 0; scale < width; scale++)
            {
                adPower += _cells[$"{cx},{yn}"];
                if (cy > 0)
                {
                    adPower += _cells[$"{xn},{cy}"];
                }

                int tx = xn - scale, ty = yn - scale;

                ScoreValue squareCell = _cellsGrid2[$"{tx},{ty}"];
                squareCell.Value += adPower;
                if(squareCell.Value > squareCell.MaxValue)
                {
                    squareCell.MaxValue = squareCell.Value;
                    squareCell.Scale = scale+1;
                }

                cx--;
                cy--;
            }
        }

        public string Task1()
        {
            GetValues();

            string cellKey = "";
            int power = 0;
            foreach(var cell in _cellsGrid)
            {
                if(cell.Value > power)
                {
                    cellKey = cell.Key;
                    power = cell.Value;
                }
            }

            return cellKey;
        }

        public string Task2()
        {
            string cellKey = "";
            int power = 0;
            foreach (var cell in _cellsGrid2)
            {
                if (cell.Value.MaxValue > power)
                {
                    cellKey = cell.Key + "," + cell.Value.Scale;
                    power = cell.Value.MaxValue;
                }
            }

            return cellKey;
        }

        class ScoreValue
        {
            public int Value;
            public int MaxValue;
            public int Scale;
        }
    }
}
