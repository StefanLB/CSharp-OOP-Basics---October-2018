using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var department = tokens[0];
                var patient = tokens[3];
                var fullName = tokens[1] + tokens[2];

                CheckAddDoctor(doctors, fullName);
                CheckAddDepartment(departments, department);

                bool enoughSpace = departments[department].SelectMany(x => x).Count() < 60;
                if (enoughSpace)
                {
                    AdmitPatient(doctors, fullName, patient, departments, department);
                }

                command = Console.ReadLine();
            }
            command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();
                PrintRequested(tokens, departments, doctors);

                command = Console.ReadLine();
            }
        }

        private static void PrintRequested(string[] tokens, Dictionary<string, List<List<string>>> departments, Dictionary<string, List<string>> doctors)
        {
            if (tokens.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[tokens[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (tokens.Length == 2 && int.TryParse(tokens[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departments[tokens[0]][room - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[tokens[0] + tokens[1]].OrderBy(x => x)));
            }
        }

        private static void AdmitPatient(Dictionary<string, List<string>> doctors, string fullName, string patient, Dictionary<string, List<List<string>>> departments, string department)
        {
            int room = 0;
            doctors[fullName].Add(patient);
            for (int i = 0; i < departments[department].Count; i++)
            {
                if (departments[department][i].Count < 3)
                {
                    room = i;
                    break;
                }
            }
            departments[department][room].Add(patient);
        }

        private static void CheckAddDepartment(Dictionary<string, List<List<string>>> departments, string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private static void CheckAddDoctor(Dictionary<string, List<string>> doctors, string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
