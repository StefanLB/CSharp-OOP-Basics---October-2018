﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations
{
    public class Citizen : IIdable,INamable,IBirthable
    {
        private string id;
        private string name;
        private int age;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
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

        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
    }
}
