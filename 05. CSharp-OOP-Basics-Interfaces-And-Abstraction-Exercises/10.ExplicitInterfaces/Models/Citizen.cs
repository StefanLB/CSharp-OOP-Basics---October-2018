using _10.ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        private string name;
        private string country;
        private int age;

        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string Country
        {
            get { return country; }
            set { this.country = value; }
        }

        public int Age
        {
            get { return age; }
            set { this.age = value; }
        }

        public Citizen() { }

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }

        string IPerson.GetName()
        {
            return Name;
        }
    }
}
