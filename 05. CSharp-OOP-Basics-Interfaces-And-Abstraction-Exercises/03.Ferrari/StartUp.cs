using System;

namespace _03.Ferrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();
            Ferrari ferraru = new Ferrari(driverName);

            Console.WriteLine(ferraru.ToString());
        }
    }
}
