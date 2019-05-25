using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities
{
    public class DistributionCenter : Storage
    {
        private const int DistributionCenterCapacity = 2;
        private const int DistributionCenterGarageSlots = 5;
        public DistributionCenter(string name)
            : base(name,
                  DistributionCenterCapacity,
                  DistributionCenterGarageSlots,
                  new Vehicle[DistributionCenterGarageSlots] { new Van(), new Van(), new Van(), null, null })
        {
        }
    }
}
