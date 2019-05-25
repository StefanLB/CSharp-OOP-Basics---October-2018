using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Kitten : Cat
    {
        public override string ProduceSound()
        {
            return "Meow";
        }

        public Kitten(string name,string age)
            :base(name,age,"Female")
        {
        }
    }
}
