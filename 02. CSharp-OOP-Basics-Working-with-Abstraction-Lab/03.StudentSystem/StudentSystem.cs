using System;
using System.Collections.Generic;
using System.Text;

namespace _03.StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> students;

        public StudentSystem()
        {
            this.Students = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Students
        {
            get { return students; }
            private set { students = value; }
        }

        public void Create(string[] tokens)
        {
            var name = tokens[1];
            var age = int.Parse(tokens[2]);
            var grade = double.Parse(tokens[3]);
            if (!students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Students[name] = student;
            }
        }

        public string Show(string[] tokens)
        {
            var name = tokens[1];
            if (Students.ContainsKey(name))
            {
                var student = Students[name];
                string view = $"{student.Name} is {student.Age} years old.";

                if (student.Grade >= 5.00)
                {
                    view += " Excellent student.";
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    view += " Average student.";
                }
                else
                {
                    view += " Very nice person.";
                }

                return view;
            }

            return "";
        }
    }
}
