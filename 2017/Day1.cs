using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC
{
    enum Direction
    {
        North,
        East,
        South,
        West
    }

    class Day1
    {
        Direction _dir = Direction.North;
        int _x = 0;
        int _y = 0;

        List<Tuple<int, int>> _points = new();
        Tuple<int, int> _intersect;
        

        readonly string[] _input = { "R3", "L2", "L2", "R4", "L1", "R2", "R3", "R4", "L2", "R4", "L2", "L5", "L1", "R5", "R2", "R2", "L1", "R4", "R1", "L5", "L3", "R4", "R3", "R1", "L1", "L5", "L4", "L2", "R5", "L3", "L4", "R3", "R1", "L3", "R1", "L3", "R3", "L4", "R2", "R5", "L190", "R2", "L3", "R47", "R4", "L3", "R78", "L1", "R3", "R190", "R4", "L3", "R4", "R2", "R5", "R3", "R4", "R3", "L1", "L4", "R3", "L4", "R1", "L4", "L5", "R3", "L3", "L4", "R1", "R2", "L4", "L3", "R3", "R3", "L2", "L5", "R1", "L4", "L1", "R5", "L5", "R1", "R5", "L4", "R2", "L2", "R1", "L5", "L4", "R4", "R4", "R3", "R2", "R3", "L1", "R4", "R5", "L2", "L5", "L4", "L1", "R4", "L4", "R4", "L4", "R1", "R5", "L1", "R1", "L5", "R5", "R1", "R1", "L3", "L1", "R4", "L1", "L4", "L4", "L3", "R1", "R4", "R1", "R1", "R2", "L5", "L2", "R4", "L1", "R3", "L5", "L2", "R5", "L4", "R5", "L5", "R3", "R4", "L3", "L3", "L2", "R2", "L5", "L5", "R3", "R4", "R3", "R4", "R3", "R1" };

        private void Reset()
        {
            _dir = Direction.North; _x = 0; _y = 0; _points = new List<Tuple<int, int>>();
        }


        public int Task1()
        {
            Reset();
            foreach(string command in _input)
            {
                string turn = command.Substring(0, 1);
                int distance = int.Parse(command[1..]);

                ChangeDirection(turn);

                Transit(distance);
            }

            var result = _x + _y;

            return result;
        }

        public int Task2()
        {
            Reset();
            foreach (string command in _input)
            {
                string turn = command.Substring(0, 1);
                int distance = int.Parse(command[1..]);

                ChangeDirection(turn);

                TransitWithIntersect(distance);

                if(_intersect != null)
                {
                    return _intersect.Item1 + _intersect.Item2;
                }
            }

            return _x + _y;
        }

        void ChangeDirection(string turn)
        {
            bool left = turn == "L";
            bool right = turn == "R";

            if (left)
            {
                _dir--;
                if ((int)_dir == -1)
                    _dir = Direction.West;
            }
            else if (right)
            {
                _dir++;
                if ((int)_dir == 4)
                    _dir = Direction.North;
            }
        }

        void Transit(int distance)
        {
            switch (_dir)
            {
                case Direction.North:
                    _y+=distance;
                    break;
                case Direction.East:
                    _x += distance;
                    break;
                case Direction.South:
                    _y -= distance;
                    break;
                case Direction.West:
                    _x -= distance;
                    break;
                default:
                    break;
            }
        }

        void TransitWithIntersect(int distance)
        {
            int moveX = 0, moveY = 0;

            switch (_dir)
            {
                case Direction.North:
                    moveY = distance;
                    break;
                case Direction.East:
                    moveX = distance;
                    break;
                case Direction.South:
                    moveY = -distance;
                    break;
                case Direction.West:
                    moveX = -distance;
                    break;
                default:
                    break;
            }

            int sign = moveX != 0 ? (moveX / Math.Abs(moveX)) : (moveY / Math.Abs(moveY));

            for (int i = 0; i < Math.Abs(moveX); i++)
            {
                _x += sign;
                var newPoint = Tuple.Create(_x, _y);
                if(_points.Any(s=>s.Item1 == newPoint.Item1 && s.Item2 == newPoint.Item2))
                {
                    _intersect = newPoint;
                    return;
                }

                _points.Add(newPoint);
            }

            for (int i = 0; i < Math.Abs(moveY); i++)
            {
                _y += sign;
                var newPoint = Tuple.Create(_x, _y );
                if (_points.Any(s => s.Item1 == newPoint.Item1 && s.Item2 == newPoint.Item2))
                {
                    _intersect = newPoint;
                    return;
                }

                _points.Add(newPoint);
            }
        }
    }
}
