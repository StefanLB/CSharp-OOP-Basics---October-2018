using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Person
{
    public class Person
    {
        private const int NAME_MIN_LENGTH = 3;
        private string name;
        private int age;

        public virtual int Age
        {
            get { return age; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Age must be positive!");
                }
                age = value;
            }
        }

        public virtual string Name
        {
            get { return name; }
            set
            {
                if (value.Length< NAME_MIN_LENGTH)
                {
                    throw new ArgumentException($"Name's length should not be less than {NAME_MIN_LENGTH} symbols!");
                }
                name = value;
            }
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}, Age: {Age}");
            return sb.ToString();
        }
    }
}
