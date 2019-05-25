using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
    public class Parent
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private string birthday;

        public string Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }

        public Parent(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }


    }
}
