using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
    public class Company
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private string department;

        public string Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        private decimal salary;

        public decimal Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public Company(string name, string department, decimal salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }

        public override string ToString()
        {
            if (this.Name != null || this.Department != null || this.Salary != 0)
            {
                return "\n" + this.Name + " " + this.Department + " " + $"{this.Salary:F2}";
            }
            return "";
        }
    }
}
