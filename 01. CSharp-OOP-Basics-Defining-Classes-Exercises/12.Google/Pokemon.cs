using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
    public class Pokemon
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private string type;

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
