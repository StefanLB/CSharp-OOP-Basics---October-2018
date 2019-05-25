using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    public class Human
    {
        private const int MIN_FIRSTNAME_LENGTH = 4;
        private const int MIN_LASTNAME_LENGTH = 3;
        private string firstName;
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: lastName");
                }
                else if (value.Length<MIN_LASTNAME_LENGTH)
                {
                    throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
                }
                lastName = value;
            }
        }


        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: firstName");
                }
                else if (value.Length<MIN_FIRSTNAME_LENGTH)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
                }
                firstName = value;
            }
        }

    }
}
