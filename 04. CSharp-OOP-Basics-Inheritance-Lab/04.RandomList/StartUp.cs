using System;
using System.Collections.Generic;

namespace _04.RandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", };

            while (randomList.Count>0)
            {
                Console.WriteLine(randomList.RandomString());
                Console.WriteLine(randomList.Count);
            }

            Console.WriteLine(randomList.RandomString());
        }
    }
}
