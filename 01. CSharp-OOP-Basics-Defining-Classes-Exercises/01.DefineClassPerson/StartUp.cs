using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Age = 15;
            person.Name = "Yosemity Sam";

            Console.WriteLine($"This is {person.Name}. He is {person.Age} years old");
        }
    }
}
