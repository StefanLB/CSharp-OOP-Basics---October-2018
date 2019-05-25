using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Citizen : IIdable
    {
        private string id;
        private string name;
        private int age;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
