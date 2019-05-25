using System;
using System.Collections.Generic;
using System.Text;

namespace _01.SortPersonsByNameAndAge
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public int Age
        {
            get { return age; }
        }


        public string LastName
        {
            get { return lastName; }
        }


        public string FirstName
        {
            get { return firstName; }
        }

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }
}
