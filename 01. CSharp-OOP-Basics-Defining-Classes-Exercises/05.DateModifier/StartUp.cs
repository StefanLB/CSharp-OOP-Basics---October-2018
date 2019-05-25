using System;

namespace _05.DateModifier
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            var dateOne = Console.ReadLine();
            var dateTwo = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            var result = dateModifier.FindDifference(dateOne, dateTwo);
            Console.WriteLine(result);
        }
    }
}
