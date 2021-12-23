using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC._2021
{
//#############
//#...........#
//###B#C#B#D###
//# A#D#C#A#
//#########

    class Day23 : TestClass, ITestClass
    {
        private const char WallChar = '#';
        private const byte CorridorIndex = 1;

        private readonly HashSet<char> _podNames = new()
        {
            'A',
            'B',
            'C',
            'D'
        };

        private readonly Dictionary<char, byte> _homes = new()
        {
            ['A'] = 3,
            ['B'] = 5,
            ['C'] = 7,
            ['D'] = 9
        };

        private readonly Dictionary<char, int> _moveCosts = new()
        {
            ['A'] = 1,
            ['B'] = 10,
            ['C'] = 100,
            ['D'] = 1000
        };

        private GridState ReadGrid(int part)
        {
            _input = ReadInputFile(useDemo: false, part);

            string[] lines = GetVerticalSplitLines();
            _input = null;

            Cell[,] grid = new Cell[lines.Length, lines[0].Length];

            HashSet<byte> homeIndexes = new();

            for(byte y = 0; y < lines.Length; y++)
            {
                for (byte x = 0; x < lines[y].Length; x++)
                {
                    char name = lines[y][x];
                    if (_podNames.Contains(name))
                    {
                        grid[y, x] = new Pod(name, _homes[name], _moveCosts[name], IsHome: false);
                        homeIndexes.Add(x);
                    }
                    else if(name == WallChar)
                    {
                        grid[y, x] = new Wall();
                    }
                }
            }

            for(int y = grid.GetLength(0) - 2; y > CorridorIndex; y--)
            {
                foreach(int x in homeIndexes)
                {
                    Pod pod = grid[y, x] as Pod;
                    if(pod is not null && pod.HomeIndex == x)
                    {
                        Pod podBelow = grid[y + 1, x] as Pod;
                        if(podBelow == null || podBelow.IsHome)
                        {
                            grid[y, x] = pod.MoveHome();
                        }
                    }
                }
            }

            return new GridState(grid, Cost: 0);
        }

        public object Task1()
        {
            GridState startGrid = ReadGrid(part: 1);
            return FindShortestPath(startGrid);
        }

        public object Task2()
        {
            GridState startGrid = ReadGrid(part: 2);
            return FindShortestPath(startGrid);
        }

        private static object FindShortestPath(GridState startGrid)
        {
            Dictionary<int, long> previousAttempts = new();

            SimplePriorityQueue<GridState, long> queue = new();
            queue.Enqueue(startGrid, 0);

            void Enqueue(GridState newState)
            {
                int hash = newState.GetHashCode();
                if (!previousAttempts.TryGetValue(hash, out long prevCost) || newState.Cost < prevCost)
                {
                    queue.Enqueue(newState, newState.Cost);
                    previousAttempts[hash] = newState.Cost;
                }
            }

            GridState lowestScore = null;
            while (queue.Count > 0)
            {
                GridState gridState = queue.Dequeue();
                Cell[,] grid = gridState.Grid;

                //Keep moving until everything is home
                if (IsComplete(gridState) && (lowestScore == null || gridState.Cost < lowestScore.Cost))
                {
                    lowestScore = gridState;
                    continue;
                }

                for (int y = 1; y < gridState.Height; y++)
                {
                    for (int x = 0; x < gridState.Width; x++)
                    {
                        Cell cell = grid[y, x];
                        if (cell is Pod pod)
                        {
                            if (pod.IsHome) continue;

                            if (y == CorridorIndex)
                            {
                                //Find way home
                                if (TryGoHome(gridState, x, y, out GridState newState))
                                {
                                    Enqueue(newState);
                                }
                            }
                            else
                            {
                                //Find ways out
                                foreach (var newGrid in FindWaysOut(gridState, x, y))
                                {
                                    Enqueue(newGrid);
                                }
                            }
                        }
                    }
                }
            }

            return lowestScore?.Cost ?? 0;
        }

        private static bool IsComplete(GridState gridState)
        {
            for(int y = 1; y < gridState.Height; y++)
            {
                for(int x = 1; x < gridState.Width; x++)
                {
                    if(gridState.Grid[y,x] is Pod pod && !pod.IsHome)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static IEnumerable<GridState> FindWaysOut(GridState gridState, int podX, int podY)
        {
            Cell[,] grid = gridState.Grid;

            if (grid[podY - 1, podX] == null)
            {
                //Not blocked by pod above
                //Not already occupied
                //Not above cave
                Pod pod = (Pod)grid[podY, podX];

                for (int x = podX; x < gridState.Width; x++)
                {
                    if (grid[CorridorIndex, x] == null)
                    {
                        if (grid[CorridorIndex + 1, x] is Wall)
                        {
                            yield return gridState.MovePod(pod, podX, podY, x, CorridorIndex);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                for (int x = podX -1; x > 0; x--)
                {
                    if (grid[CorridorIndex, x] == null)
                    {
                        if (grid[CorridorIndex + 1, x] is Wall)
                        {
                            yield return gridState.MovePod(pod, podX, podY, x, CorridorIndex);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static bool TryGoHome(GridState gridState, int podX, int podY, out GridState newState)
        {
            newState = null;

            Cell[,] grid = gridState.Grid;

            Pod pod = (Pod)grid[podY, podX];

            //Check pod home state

            int toY = FindHomeIndex(grid, pod);
            if(toY == -1)
            {
                return false;
            }

            //Check pod path is not blocked
            if (podX < pod.HomeIndex)
            {
                for(int x = podX + 1; x <= pod.HomeIndex; x++)
                {
                    if(grid[CorridorIndex, x] != null)
                    {
                        return false;
                    }
                }
            }
            else if(podX > pod.HomeIndex)
            {
                for(int x = pod.HomeIndex; x < podX; x++)
                {
                    if (grid[CorridorIndex, x] != null)
                    {
                        return false;
                    }
                }
            }

            Pod movedPod = pod.MoveHome();

            newState = gridState.MovePod(movedPod, podX, podY, pod.HomeIndex, toY);
            return true;
        }

        private static int FindHomeIndex(Cell[,] grid, Pod pod)
        {
            int y = grid.GetLength(0) - 1;
            while (y > CorridorIndex)
            {
                Cell cell = grid[y, pod.HomeIndex];

                if(cell is null)
                {
                    return y;
                }
                else if(cell is Pod homePod && !homePod.IsHome)
                {
                    return -1;
                }

                y--;
            }
            return -1;
        }

        record Cell();
        record Wall() : Cell();
        record Pod(char Name, byte HomeIndex, int Cost, bool IsHome) : Cell()
        {
            internal Pod MoveHome()
            {
                return this with { IsHome = true };
            }
        }

        record GridState(Cell[,] Grid, long Cost)
        {
            public int Height => Grid.GetLength(0);
            public int Width => Grid.GetLength(1);

            public List<(int x, int y, char n, long score, long totalCost)> History = new();

            private static int Distance(int fromX, int fromY, int toX, int toY)
            {
                return Math.Abs(toY - fromY) + Math.Abs(toX - fromX);
            }

            private Cell[,] CopyGrid()
            {
                Cell[,] newGrid = Grid.Clone() as Cell[,];
                return newGrid;
            }

            public GridState MovePod(Pod pod, int fromX, int fromY, int toX, int toY)
            {
                Cell[,] newGrid = CopyGrid();

                newGrid[fromY, fromX] = null;
                newGrid[toY, toX] = pod;

                int moveDistance = Distance(fromX, fromY, toX, toY);
                long moveCost = (long)pod.Cost * moveDistance;

                var history = History.ToList();
                history.Add((toX, toY, pod.Name, moveCost, Cost + moveCost));

                return this with
                {
                    Grid = newGrid,
                    Cost = Cost + moveCost,
                    History = history
                };
            }

            public override int GetHashCode()
            {
                StringBuilder sb = new();
                for(int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (Grid[y, x] is Pod pod)
                        {
                            sb.Append(pod.Name);
                        }
                        else
                        {
                            sb.Append(' ');
                        }
                    }
                }

                return sb.ToString().GetHashCode();
            }
        }

    }
}
