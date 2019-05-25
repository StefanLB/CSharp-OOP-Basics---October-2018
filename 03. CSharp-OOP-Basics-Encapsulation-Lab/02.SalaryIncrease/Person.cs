using System;
using System.Collections.Generic;
using System.Text;

namespace _02.SalaryIncrease
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
        }


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

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
        }

        public void IncreaseSalary(decimal percent)
        {
            if (Age>=30)
            {
                this.salary = salary * (1 + percent/100);
            }
            else
            {
                this.salary = salary * (1 + percent / 200);
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
