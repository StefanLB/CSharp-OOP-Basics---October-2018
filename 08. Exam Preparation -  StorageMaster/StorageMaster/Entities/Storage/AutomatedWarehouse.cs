using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities
{
    public class AutomatedWarehouse : Storage
    {
        private const int AutomatedWarehouseCapacity = 1;
        private const int AutomatedWarehouseGarageSlots = 2;
        public AutomatedWarehouse(string name)
            : base(name,
                  AutomatedWarehouseCapacity,
                  AutomatedWarehouseGarageSlots,
                  new Vehicle[AutomatedWarehouseGarageSlots] {new Truck(),null})
        {
        }
    }
}
