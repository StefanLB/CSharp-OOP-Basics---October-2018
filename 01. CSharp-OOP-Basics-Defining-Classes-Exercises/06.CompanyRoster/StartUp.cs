using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CompanyRoster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var employees = new Dictionary<string,List<Employee>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                decimal salary = decimal.Parse(tokens[1]);
                string position = tokens[2];
                string department = tokens[3];

                var employee = new Employee(name, salary, position, department);

                if (tokens.Length == 6) // email AND age provided
                {
                    string email = tokens[4];
                    int age = int.Parse(tokens[5]);

                    employee.Email = email;
                    employee.Age = age;
                }
                else if (tokens.Length == 5) // email OR age provided
                {
                    if (tokens[4].Contains("@"))
                    {
                        string email = tokens[4];
                        employee.Email = email;
                    }
                    else
                    {
                        int age = int.Parse(tokens[4]);
                        employee.Age = age;
                    }
                }

                if (!employees.ContainsKey(department))
                {
                    employees.Add(department, new List<Employee>());
                }
                employees[department].Add(employee);
            }

            List<Employee> highestAverageSalary = (employees.OrderByDescending(x => x.Value.Average(y => y.Salary)).ToList()[0]).Value;

            Console.WriteLine($"Highest Average Salary: {highestAverageSalary[0].Department}");

            foreach (var employee in highestAverageSalary.OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}
