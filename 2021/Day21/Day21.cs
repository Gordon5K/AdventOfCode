using System.Collections.Generic;
using System.Linq;

namespace AOC._2021
{
    class Day21 : TestClass, ITestClass
    {
        public Day21()
        {
            _input = ReadInputFile(useDemo: false);
        }

        private (Queue<byte> playerTurns, Dictionary<byte, byte> playerPositions, Dictionary<byte, ushort> playerScores) ReadInput()
        {
            string[] lines = GetVerticalSplitLines();

            Queue<byte> playerTurns = new();
            Dictionary<byte, byte> playerPositions = new();
            Dictionary<byte, ushort> playerScores = new();

            for (byte i = 0; i < lines.Length; i++)
            {
                byte playerId = (byte)(i + 1);
                playerPositions.Add(playerId, byte.Parse(lines[i][^1].ToString()));
                playerScores.Add(playerId, 0);
                playerTurns.Enqueue(playerId);
            }
            
            return (playerTurns, playerPositions, playerScores);
        }

        public object Task1()
        {
            var (playerTurns, playerPositions, playerScores) = ReadInput();
            Game1 game = new(playerTurns, playerPositions, playerScores);
            game.Play();
            return game.MinScore * game.Rolls;
        }

        public object Task2()
        {
            var (playerTurns, playerPositions, playerScores) = ReadInput();
            Game2 game = new(playerTurns, playerPositions, playerScores);
            game.Play();
            return game.MostWins;
        }
    }

    class Game
    {
        protected Game() { }
        protected const byte MaxPosition = 10;
    }

    class Game1 : Game
    {
        private readonly Queue<byte> _playerTurns;
        private readonly Dictionary<byte, byte> _playerPositions;
        private readonly Dictionary<byte, ushort> _playerScores;

        private readonly Die _die = new(sides: 100);

        public int Rolls => _die.Rolls;
        public ushort MinScore => _playerScores.Values.Min();

        public Game1(Queue<byte> playerTurns, Dictionary<byte, byte> playerPositions, Dictionary<byte, ushort> playerScores)
        {
            _playerTurns = playerTurns;
            _playerPositions = playerPositions;
            _playerScores = playerScores;
        }

        public void Play()
        {
            byte playerId = _playerTurns.Dequeue();
            while (!MoveToWin(playerId, winScore: 1000))
            {
                _playerTurns.Enqueue(playerId);
                playerId = _playerTurns.Dequeue();
            }
        }

        private bool MoveToWin(byte playerId, int winScore)
        {
            ushort toMove = 0;
            for (int i = 0; i < 3; i++)
            {
                toMove += _die.Roll();
            }

            ushort playerPosition = _playerPositions[playerId];
            playerPosition += toMove;

            if (playerPosition > MaxPosition)
            {
                playerPosition = (byte)(playerPosition % MaxPosition);
                if (playerPosition == 0)
                {
                    playerPosition = MaxPosition;
                }
            }
            _playerPositions[playerId] = (byte)playerPosition;
            _playerScores[playerId] += playerPosition;

            return _playerScores[playerId] >= winScore;
        }

        class Die
        {
            private readonly byte _sides;
            private byte _score = 0;

            public int Rolls { get; private set; } = 0;

            public Die(byte sides)
            {
                _sides = sides;
            }

            public byte Roll()
            {
                Rolls++;
                _score++;
                if (_score > _sides)
                {
                    _score = 1;
                }

                return _score;
            }
        }
    }

    class Game2 : Game
    {
        record PlayerState(byte PlayerId, byte Position, byte Score)
        {
            public PlayerState Move(byte diceScore)
            {
                ushort playerPosition = Position;
                playerPosition += diceScore;

                if (playerPosition > MaxPosition)
                {
                    playerPosition = (byte)(playerPosition % MaxPosition);
                    if (playerPosition == 0)
                    {
                        playerPosition = MaxPosition;
                    }
                }

                return this with { Position = (byte)playerPosition, Score = (byte)(Score + playerPosition) };
            }
        }

        private const byte WinScore = 21;

        Dictionary<(PlayerState p1, PlayerState p2), ulong> _games = new();
        private readonly Dictionary<byte, ulong> _playerWins = new();

        public ulong MostWins => _playerWins.Values.Max();

        public Game2(Queue<byte> playerTurns, Dictionary<byte, byte> playerPositions, Dictionary<byte, ushort> playerScores)
        {
            byte player1 = playerTurns.Dequeue();
            byte player2 = playerTurns.Dequeue();

            _playerWins.Add(player1, 0);
            _playerWins.Add(player2, 0);

            _games.Add((
                new PlayerState(player1, playerPositions[player1], (byte)playerScores[player1]),
                new PlayerState(player2, playerPositions[player2], (byte)playerScores[player2])), 1);
        }

        public void Play()
        {
            ulong i = 0;
            while(_games.Count > 0)
            {
                Dictionary<(PlayerState player, PlayerState opponent), ulong> newGames = new();

                var rolls = SpawnRolls();
                foreach (((PlayerState player, PlayerState opponent), ulong gCount) in _games)
                {
                    foreach (var (rollTotal, count) in rolls)
                    {
                        PlayerState movedPlayer = player.Move(rollTotal);
                        if (movedPlayer.Score >= WinScore)
                        {
                            _playerWins[player.PlayerId] += (gCount * count);
                        }
                        else
                        {
                            var nextRound = (opponent, movedPlayer); //Switch player and opponent
                            ulong newGameCount = gCount * count;
                            if (newGames.ContainsKey(nextRound))
                            {
                                newGames[nextRound] += newGameCount;
                            }
                            else
                            {
                                newGames.Add(nextRound, newGameCount);
                            }
                        }
                    }
                }
                i++;
                _games = newGames;
            }
        }

        private static (byte rollTotal, byte count)[] SpawnRolls() => _rollScores;

        private static readonly (byte, byte)[] _rollScores = new(byte, byte)[] 
        { 
            (3, 1),
            (4, 3),
            (5, 6),
            (6, 7),
            (7, 6),
            (8, 3),
            (9, 1)
        };

}
}
