using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var teams = new List<Team>();

            while (true)
            {
                try
                {
                    var input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    var parametes = input.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
                    var command = parametes.FirstOrDefault();
                    parametes = parametes.Skip(1).ToList();

                    if (command.ToLowerInvariant() == "team")
                    {
                        AddTeam(teams, parametes);
                    }
                    else if (command.ToLowerInvariant() == "add")
                    {
                        AddPlayerToTeam(teams, parametes);
                    }
                    else if (command.ToLowerInvariant() == "remove")
                    {
                        RemoveTeamPlayer(teams, parametes);
                    }
                    else if (command.ToLowerInvariant() == "rating")
                    {
                        PrintRating(teams, parametes);
                    }
                }

                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    continue;
                }
            }
        }

        private static void PrintRating(List<Team> teams, List<string> parametes)
        {
            var teamName = parametes[0];
            var team = teams.First(t => t.Name.ToLowerInvariant() == teamName.ToLowerInvariant());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(team);
            Console.ResetColor();
        }

        private static void RemoveTeamPlayer(List<Team> teams, List<string> parametes)
        {
            var teamName = parametes[0];
            var playerName = parametes[1];
            var team = teams.First(t => t.Name.ToLowerInvariant() == teamName.ToLowerInvariant());
            team.RemovePlayer(playerName);
        }

        private static void AddPlayerToTeam(List<Team> teams, List<string> parametes)
        {
            var teamName = parametes[0];
            var team = teams.FirstOrDefault(t => t.Name.ToLowerInvariant() == teamName.ToLowerInvariant());

            if (team == null)
            {
                throw new NullReferenceException($"Team {teamName} does not exist.");
            }

            var playerName = parametes[1];
            var endurance = int.Parse(parametes[2]);
            var sprint = int.Parse(parametes[3]);
            var dribble = int.Parse(parametes[4]);
            var passing = int.Parse(parametes[5]);
            var shooting = int.Parse(parametes[6]);

            var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(player);
        }

        private static void AddTeam(List<Team> teams, List<string> parametes)
        {
            var team = new Team(parametes.FirstOrDefault());
            teams.Add(team);
        }
    }
}
