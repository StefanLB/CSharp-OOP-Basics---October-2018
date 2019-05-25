using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "DJAAF";
        }

        public Dog(string name, string favouriteFood)
            :base(name,favouriteFood)
        {
        }
    }
}
