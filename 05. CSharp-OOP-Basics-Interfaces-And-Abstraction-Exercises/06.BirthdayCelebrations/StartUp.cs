using System;
using System.Collections.Generic;

namespace _06.BirthdayCelebrations
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

            string birthyear = Console.ReadLine();

            PrintFakeIds(inhabitants, birthyear);
        }

        private static void PrintFakeIds(List<object> inhabitants, string birthyear)
        {
            foreach (var inhabitant in inhabitants)
            {
                if (inhabitant is Citizen citizen)
                {
                    if (citizen.Birthdate.EndsWith(birthyear))
                    {
                        Console.WriteLine(citizen.Birthdate);
                    }
                }
                else if (inhabitant is Pet pet)
                {
                    if (pet.Birthdate.EndsWith(birthyear))
                    {
                        Console.WriteLine(pet.Birthdate);
                    }
                }
            }
        }

        private static void AddInhabitant(List<object> inhabitants, string command)
        {
            string[] tokens = command.Split();

            if (tokens[0] == "Robot")
            {
                inhabitants.Add(new Robot(tokens[1], tokens[2]));
            }
            else if (tokens[0] == "Citizen")
            {
                inhabitants.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3],tokens[4]));
            }
            else if (tokens[0] == "Pet")
            {
                inhabitants.Add(new Pet(tokens[1], tokens[2]));
            }
        }
    }
}
