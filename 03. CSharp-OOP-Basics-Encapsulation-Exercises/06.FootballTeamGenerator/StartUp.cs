using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var teams = new List<Team>();

            while (command != "END")
            {
                try
                {
                    string[] tokens = command.Split(';');
                    string action = tokens[0];
                    switch (action.ToLower())
                    {
                        case "team":
                            CreateTeam(teams, tokens);
                            break;
                        case "add":
                            AddPlayerToTeam(teams, tokens);
                            break;
                        case "remove":
                            RemovePlayerFromTeam(teams, tokens);
                            break;
                        case "rating":
                            ShowTeamRating(teams, tokens);
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }
        }

        static void ShowTeamRating(List<Team> teams, string[] tokens)
        {
            string teamRatingToShow = tokens[1];

            if (!teams.Any(x => x.Name == teamRatingToShow))
            {
                throw new ArgumentException($"Team {teamRatingToShow} does not exist.");
            }

            Console.WriteLine($"{teamRatingToShow} - {teams.FirstOrDefault(x => x.Name == teamRatingToShow).Rating()}");
        }

        static void RemovePlayerFromTeam(List<Team> teams, string[] tokens)
        {
            string removeFromTeam = tokens[1];
            string playerToRemove = tokens[2];

            if (!teams.Any(x => x.Name == removeFromTeam))
            {
                throw new ArgumentException($"Team {removeFromTeam} does not exist.");
            }

            int teamIndexToRem = teams.FindIndex(x => x.Name == removeFromTeam);
            teams[teamIndexToRem].RemovePlayer(playerToRemove);
        }

        static void AddPlayerToTeam(List<Team> teams, string[] tokens)
        {
            string addToTeamName = tokens[1];
            string addPlayerName = tokens[2];

            if (!teams.Any(x => x.Name == addToTeamName))
            {
                throw new ArgumentException($"Team {addToTeamName} does not exist.");
            }

            Dictionary<string, int> stats = new Dictionary<string, int>
                            {
                                {"Endurance",int.Parse(tokens[3])},
                                {"Sprint",int.Parse(tokens[4])},
                                {"Dribble", int.Parse(tokens[5])},
                                {"Passing",int.Parse(tokens[6])},
                                {"Shooting",int.Parse(tokens[7])}
                            };

            Player player = new Player(addPlayerName, stats);

            int teamIndex = teams.FindIndex(x => x.Name == addToTeamName);
            teams[teamIndex].AddPlayer(player);
        }

        static void CreateTeam(List<Team> teams, string[] tokens)
        {
            string teamName = tokens[1];
            teams.Add(new Team(teamName));
        }
    }
}
