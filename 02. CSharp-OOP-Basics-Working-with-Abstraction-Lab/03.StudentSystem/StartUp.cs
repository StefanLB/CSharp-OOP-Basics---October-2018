using System;

namespace _03.StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();
            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0] == "Create")
                {
                    studentSystem.Create(tokens);
                }
                else if (tokens[0] == "Show")
                {
                    Console.WriteLine(studentSystem.Show(tokens));
                }
                else if (tokens[0] == "Exit")
                {
                    break;
                }
            }
        }
    }
}
