using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    public class Worker : Human
    {
        private const decimal MIN_WEEKLY_SALARY = 10;
        private const decimal MAX_WEEKLY_HOURS = 12;
        private decimal weekSalary;

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value<=MIN_WEEKLY_SALARY)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }
                weekSalary = value;
            }
        }

        private decimal workHoursPerDay;

        public decimal WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value<1||value>MAX_WEEKLY_HOURS)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }
                workHoursPerDay = value;
            }
        }

        public decimal SalaryPerHour()
        {
            return WeekSalary / (WorkHoursPerDay * 5);
        }

        public Worker(string firsName, string lastName, decimal weekSalary, decimal hoursPerDay)
        {
            this.FirstName = firsName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = hoursPerDay;
        }

        public override string ToString()
        {
            return $"First Name: {FirstName}\n" +
                   $"Last Name: {LastName}\n" +
                   $"Week Salary: {WeekSalary:f2}\n" +
                   $"Hours per day: {WorkHoursPerDay:f2}\n" +
                   $"Salary per hour: {SalaryPerHour():f2}";
        }
    }
}
