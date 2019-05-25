using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public class Backpack : Bag
    {
        private const int BackPackCapacity = 100;
        public Backpack()
            : base(BackPackCapacity)
        {
        }
    }
}
