using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Person
{
    public class Child : Person
    {
        private const int CHILD_MAX_AGE = 14;
        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value > CHILD_MAX_AGE)
                {
                    throw new ArgumentException($"Child's age must be less than {CHILD_MAX_AGE + 1}!");
                }
                base.Age = value;
            }
        }
    }
}
