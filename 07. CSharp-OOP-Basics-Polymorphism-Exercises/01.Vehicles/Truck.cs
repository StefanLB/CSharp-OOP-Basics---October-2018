using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double INCREASED_CONSUMPTION = 1.6;
        private const double TANK_CAPACITY_PERCENTAGE = 0.95;

        public Truck(double fuel, double consumptionPerKm)
            : base(fuel, consumptionPerKm + INCREASED_CONSUMPTION)
        {
        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount*TANK_CAPACITY_PERCENTAGE);
        }
    }
}
