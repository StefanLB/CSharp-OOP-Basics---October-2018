using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Tomcat : Cat
    {
        public override string ProduceSound()
        {
            return "MEOW";
        }

        public Tomcat(string name, string age)
            :base(name,age,"Male")
        {
        }
    }
}
