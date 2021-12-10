using System.Collections.Generic;

namespace AOC._2018
{
    class Day9
    {
        readonly int _players = 479;
        readonly long _marbles = 71035*100;

        public string Task1()
        {
            var circle = new List<long>();
            var playerScores = new Dictionary<long, long>();

            long currentPlayer = 0;
            long current = 0;
            int currentIndex = 0;
            do
            {
                if (current > 0 && current % 23 == 0)
                {
                    if (!playerScores.ContainsKey(currentPlayer)) playerScores.Add(currentPlayer, 0);

                    long toAdd = current;

                    int toTakeIndex = currentIndex - 7;
                    if(toTakeIndex < 0)
                    {
                        toTakeIndex = circle.Count + toTakeIndex;
                    }


                    long toTakeScore = circle[toTakeIndex];
                    toAdd += toTakeScore;
                    circle.RemoveAt(toTakeIndex);
                    currentIndex = toTakeIndex;

                    playerScores[currentPlayer] += toAdd;
                }
                else
                {
                    if (circle.Count < 2)
                    {
                        circle.Add(current);
                        currentIndex = circle.Count - 1;
                    }
                    else
                    {
                        int left = currentIndex + 1;
                        if (left == circle.Count) left = 0;

                        circle.Insert(++left, current);
                        currentIndex = left;
                    }
                }

                if(currentPlayer++ == _players -1)
                {
                    currentPlayer = 0;
                }
            }
            while (current++ < _marbles);

            long playerScore = 0;
            foreach(var player in playerScores)
            {
                if (player.Value > playerScore)
                {
                    playerScore = player.Value;
                }
            }

            return playerScore.ToString();
        }

        public static string Task2()
        {
            return string.Empty;
        }
    }
}
