using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.StackOfStrings
{
    public class StackOfStrings
    {
        private List<string> data = new List<string>();

        public void Push(string element)
        {
            this.data.Add(element);
        }

        public string Pop()
        {
            var element = this.data.Last();
            this.data.Remove(element);
            return element;
        }

        public string Peek()
        {
            var element = this.data.Last();
            return element;
        }

        public bool IsEmpty()
        {
            return this.data.Count == 0;
        }
    }
}
