using _10.ExplicitInterfaces.Interfaces;
using _10.ExplicitInterfaces.Models;
using System;

namespace _10.ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine())!="End")
            {
                string[] tokens = command.Split();
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IPerson citizen = new Citizen(name,country,age);
                IResident citizen1 = new Citizen(name, country, age);

                Console.WriteLine(citizen.GetName());
                Console.WriteLine(citizen1.GetName());
            }
        }
    }
}
