using System;

namespace _05.StackOfStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOf = new StackOfStrings();

            for (int i = 0; i < 10; i++)
            {
                stackOf.Push(i.ToString());
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(stackOf.Peek());
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(stackOf.Pop());
            }
        }
    }
}
