using _09.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IUsable
    {
        public override string Remove()
        {
            string result = Collection[0];
            for (int i = 0; i < NumberOfElements-1; i++)
            {
                Collection[i] = Collection[i + 1];
            }
            NumberOfElements--;
            return result;
        }
        public int Used()
        {
            return NumberOfElements;
        }
    }
}
