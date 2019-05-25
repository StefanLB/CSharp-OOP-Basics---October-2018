using System;

namespace _03.Mankind
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] studentInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] workerInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                string firstNameS = studentInput[0];
                string lastNameS = studentInput[1];
                string facultyNumS = studentInput[2];
                Student student = new Student(firstNameS, lastNameS, facultyNumS);

                string firstNameW = workerInput[0];
                string lastNameW = workerInput[1];
                decimal weekSalary = decimal.Parse(workerInput[2]);
                decimal hoursPerDay = decimal.Parse(workerInput[3]);
                Worker worker = new Worker(firstNameW, lastNameW, weekSalary, hoursPerDay);

                Console.WriteLine(student.ToString());
                Console.WriteLine();
                Console.WriteLine(worker.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
