using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Console.WriteLine($"This is {person.Name}. He is {person.Age} years old");

            Person person2 = new Person(5);
            Console.WriteLine($"This is {person2.Name}. He is {person2.Age} years old");

            Person person3 = new Person("NotNoName", 5);
            Console.WriteLine($"This is {person3.Name}. He is {person3.Age} years old");
        }
    }
}
