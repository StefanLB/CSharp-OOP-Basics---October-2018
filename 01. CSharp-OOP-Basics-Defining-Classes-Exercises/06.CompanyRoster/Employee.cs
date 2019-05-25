using System;
using System.Collections.Generic;
using System.Text;

namespace _06.CompanyRoster
{
    public class Employee
    {
        /*name, salary, position, department, email and age. The name, salary, position and department are mandatory while the rest are optional. */

        private string name; //mandatory
        private decimal salary; //mandatory
        private string position; //mandatory
        private string department; //mandatory
        private string email = "n/a";
        private int age = -1;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public decimal Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public string Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public string Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Employee(string name, decimal salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
        }
    }
}
