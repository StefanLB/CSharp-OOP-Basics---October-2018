using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Frog : Animal
    {
        public override string ProduceSound()
        {
            return "Ribbit";
        }

        public Frog(string name, string age, string gender)
            :base(name,age,gender)
        {

        }
    }
}
