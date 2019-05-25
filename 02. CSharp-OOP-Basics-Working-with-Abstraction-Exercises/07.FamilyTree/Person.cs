using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FamilyTree
{
    public class Person
    {
        private string name;
        private string birthday;
        private List<Person> parents;
        private List<Person> children;

        public Person()
        {
            this.Children = new List<Person>();
            this.Parents = new List<Person>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public List<Person> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        public List<Person> Children
        {
            get { return children; }
            set { children = value; }
        }

        public void AddChildren(Person child)
        {
            Children.Add(child);
        }

        public void AddParents(Person parent)
        {
            Parents.Add(parent);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} {this.Birthday}");

            sb.AppendLine("Parents:");
            this.Parents.ForEach(p => sb.AppendLine($"{p.Name} {p.Birthday}"));

            sb.AppendLine("Children:");
            this.Children.ForEach(ch => sb.AppendLine($"{ch.Name} {ch.Birthday}"));

            return sb.ToString();
        }
    }
}
