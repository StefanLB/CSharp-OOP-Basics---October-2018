using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities
{
    public class Warehouse : Storage
    {
        private const int WarehouseCapacity = 10;
        private const int WarehouseGarageSlots = 10;
        public Warehouse(string name)
            : base(name,
                  WarehouseCapacity,
                  WarehouseGarageSlots,
                  new Vehicle[WarehouseGarageSlots] { new Semi(), new Semi(), new Semi(), null, null, null, null, null, null, null })
        {
        }
    }
}
