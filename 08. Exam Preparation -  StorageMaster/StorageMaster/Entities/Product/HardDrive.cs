using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities
{
    public class HardDrive : Product
    {
        private const double HardDriveWeight = 1;
        public HardDrive(double price)
            : base(price, HardDriveWeight)
        {
        }
    }
}
