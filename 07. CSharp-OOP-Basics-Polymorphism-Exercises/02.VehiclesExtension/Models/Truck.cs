using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double INCREASED_CONSUMPTION = 1.6;
        private const double TANK_CAPACITY_PERCENTAGE = 0.95;

        public Truck(double fuel, double consumptionPerKm, double tankCapacity)
            : base(fuel, consumptionPerKm + INCREASED_CONSUMPTION,tankCapacity)
        {
        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount);
            this.Fuel -= fuelAmount *(1-TANK_CAPACITY_PERCENTAGE);
        }
    }
}
