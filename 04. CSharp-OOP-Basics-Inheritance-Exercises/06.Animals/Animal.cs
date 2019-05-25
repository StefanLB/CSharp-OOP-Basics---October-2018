using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.Animals
{
    public abstract class Animal
    {
        private string name;
        private string age;
        private string gender;

        public string Gender
        {
            get { return gender; }
            set
            {
                if (string.IsNullOrEmpty(value) || (value!="Male" && value!="Female"))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }

        public string Age
        {
            get { return age; }
            set
            {
                if (string.IsNullOrEmpty(value) || !value.Any(char.IsDigit) || int.Parse(value)<0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }


        public virtual string ProduceSound()
        {
            return "Generic animal sound";
        }

        public Animal(string name, string age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public override string ToString()
        {
            return
                $"{this.GetType().Name}\n" +
                $"{Name} {Age} {Gender}\n"+
                $"{ProduceSound()}";
        }
    }
}
