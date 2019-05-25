using System;
using System.Collections.Generic;
using System.Text;

namespace _04.RandomList
{
    public class RandomList : List<string>
    {
        private Random rnd = new Random();

        public string RandomString()
        {
            var element = "List is empty.";
            if (this.Count>0)
            {
                var index = rnd.Next(0, this.Count - 1);
                element = this[index];
                this.RemoveAt(index);
            }

            return element;
        }
    }
}
