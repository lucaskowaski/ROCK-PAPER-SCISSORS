using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var tournament = new List<Player[]>
            {
                new[]
                {
                    new Player("Armando", "P"),
                    new Player("Dave", "S"),
                },
                new[]
                {
                    new Player("Richard", "R"),
                    new Player("Michael", "S"),
                },
                new[]
                {
                    new Player("Allen", "S"),
                    new Player("Omer", "P")
                },
                new[]
                {
                    new Player("David E.", "r"),
                    new Player("Richard X.", "p")
                }
            };
            var winner = RpsTournamentWinner(tournament);
            Console.WriteLine(winner.Nome + " Ganhou o Torneio");
            Console.ReadKey();
        }
        static Player RpsGameWinner(Player[] dispute)
        {
            if (dispute.Length != 2)
            {
                throw new WrongNumberOfPlayersException("Deve ter 2 jogadores");
            }
            foreach (var player in dispute)
            {
                string choice = player.Choice.ToUpper();
                if (choice != "R" && choice != "P" && choice != "S")
                {
                    throw new NoSuchStrategyExcepition("Permitido somente as opções \"R\", \"P\" ou \"S\"");
                }
            }
            Player winner = null;
            if (dispute[0].Choice == dispute[1].Choice)
            {
                winner = dispute[0];
            }
            else
            {
                switch (dispute[0].Choice.ToUpper())
                {
                    case "R":
                        if (dispute[1].Choice != "P")
                        {
                            winner = dispute[0];
                        }
                        else
                        {
                            winner = dispute[1];
                        }
                        break;
                    case "P":
                        if (dispute[1].Choice != "S")
                        {
                            winner = dispute[0];
                        }
                        else
                        {
                            winner = dispute[1];
                        }
                        break;
                    case "S":
                        if (dispute[1].Choice != "R")
                        {
                            winner = dispute[0];
                        }
                        else
                        {
                            winner = dispute[1];
                        }
                        break;
                }
            }
            return winner;

        }
        static Player RpsTournamentWinner(List<Player[]> Tournament)
        {
            List<Player> winners = new List<Player>();
            foreach (var item in Tournament)
            {
                winners.Add(RpsGameWinner(item));
            }
            if (winners.Count > 1)
            {
                var games = SplitWinners(winners);
                return RpsTournamentWinner(games);
            }
            else
            {
                return winners.First();
            }
        }
        private static List<Player[]> SplitWinners(List<Player> winners)
        {
            return SplitList<Player>(winners, 2).ToList();
        }
        private static IEnumerable<T[]> SplitList<T>(List<T> list, int pieceSize)
        {
            for (int i = 0; i < list.Count; i += pieceSize)
            {
                yield return list.GetRange(i, Math.Min(pieceSize, list.Count - i)).ToArray();
            }
        }
    }
}
