using _09.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IRemovable
    {
        public override int Add(string token)
        {
            for (int i = NumberOfElements; i > 0; i--)
            {
                Collection[i] = Collection[i - 1];
            }
            Collection[0] = token;
            NumberOfElements++;
            return 0;
        }
        public virtual string Remove()
        {
            string result = Collection[NumberOfElements - 1];
            Collection[NumberOfElements - 1] = string.Empty;
            NumberOfElements--;
            return result;
        }
    }
}
