using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> numbersToCall = Console.ReadLine().Split().ToList();
            List<string> sitesToBrowse = Console.ReadLine().Split().ToList();

            SmartPhone smartPhone = new SmartPhone(numbersToCall, sitesToBrowse);
            Console.Write(smartPhone.ToString());
        }
    }
}
