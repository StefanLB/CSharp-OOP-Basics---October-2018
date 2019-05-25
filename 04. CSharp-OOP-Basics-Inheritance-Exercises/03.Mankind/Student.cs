using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Mankind
{
    public class Student : Human
    {
        private const int FACULTY_MIN_SYMBOLS = 5;
        private const int FACULTY_MAX_SYMBOLS = 10;
        private string facultyNumber;

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                if (value.ToString().Length<FACULTY_MIN_SYMBOLS || value.ToString().Length>FACULTY_MAX_SYMBOLS || !value.All(char.IsLetterOrDigit))
                {
                    throw new ArgumentException($"Invalid faculty number!");
                }
                facultyNumber = value;
            }
        }

        public Student(string firstName, string lastName, string facultyNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
        }

        public override string ToString()
        {
            return $"First Name: {FirstName}\n" +
                    $"Last Name: {LastName}\n" +
                    $"Faculty number: {FacultyNumber}";
        }
    }
}
