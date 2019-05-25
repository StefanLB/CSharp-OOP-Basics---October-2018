﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DefineInterfaceIPerson
{
    public class Citizen : IPerson
    {
        private string name;
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

    }
}
