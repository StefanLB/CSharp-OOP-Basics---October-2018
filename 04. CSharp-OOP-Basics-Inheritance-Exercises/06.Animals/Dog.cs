using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Dog : Animal
    {
        public override string ProduceSound()
        {
            return "Woof!";
        }
        public Dog(string name, string age, string gender)
            :base (name,age,gender)
        {

        }
    }
}
