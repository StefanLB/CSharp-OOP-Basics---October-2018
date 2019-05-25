using System;
using System.Collections.Generic;
using System.Text;

namespace _04.FirstAndReserveTeam
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value<460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
                salary = value;
            }

        }


        public int Age
        {
            get { return age; }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }


        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                lastName = value;
            }
        }


        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                firstName = value;
            }
        }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public void IncreaseSalary(decimal percent)
        {
            if (Age>=30)
            {
                this.Salary = salary * (1 + percent/100);
            }
            else
            {
                this.Salary = salary * (1 + percent / 200);
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
