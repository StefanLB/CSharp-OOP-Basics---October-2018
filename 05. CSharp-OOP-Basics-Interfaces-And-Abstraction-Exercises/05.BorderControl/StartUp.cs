using System;
using System.Collections.Generic;

namespace _05.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<object> inhabitants = new List<object>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                AddInhabitant(inhabitants, command);
            }

            string fakeId = Console.ReadLine();

            PrintFakeIds(inhabitants, fakeId);
        }

        private static void PrintFakeIds(List<object> inhabitants, string fakeId)
        {
            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant is Citizen)
                {
                    Citizen citizen = (Citizen)inhabitant;
                    if (citizen.Id.EndsWith(fakeId))
                    {
                        Console.WriteLine(citizen.Id);
                    }
                }
                else
                {
                    Robot robot = (Robot)inhabitant;
                    if (robot.Id.EndsWith(fakeId))
                    {
                        Console.WriteLine(robot.Id);
                    }
                }
            }
        }

        private static void AddInhabitant(List<object> inhabitants, string command)
        {
            string[] tokens = command.Split();

            if (tokens.Length == 2)
            {
                inhabitants.Add(new Robot(tokens[0], tokens[1]));
            }
            else if (tokens.Length == 3)
            {
                inhabitants.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
        }
    }
}
