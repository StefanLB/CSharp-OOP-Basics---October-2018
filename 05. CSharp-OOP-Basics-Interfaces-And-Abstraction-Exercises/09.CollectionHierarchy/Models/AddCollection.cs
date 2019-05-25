using _09.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        private string[] collection;
        private int numberOfElements;

        public string[] Collection
        {
            get { return this.collection; }
            set { this.collection = value; }
        }
        public int NumberOfElements
        {
            get { return this.numberOfElements; }
            set { this.numberOfElements = value; }
        }

        public AddCollection()
        {
            this.Collection = new string[100];
            this.NumberOfElements = 0;
        }
        public virtual int Add(string token)
        {
            Collection[numberOfElements++] = token;
            return NumberOfElements- 1;
        }
    }
}
