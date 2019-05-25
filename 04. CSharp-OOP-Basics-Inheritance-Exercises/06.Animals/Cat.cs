using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Cat : Animal
    {
        public override string ProduceSound()
        {
            return "Meow meow";
        }

        public Cat(string name, string age, string gender)
            :base(name,age,gender)
        {

        }
    }
}
