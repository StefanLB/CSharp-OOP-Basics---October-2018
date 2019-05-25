using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double INCREASED_CONSUMPTION = 0.9;
        public Car(double fuel, double consumptionPerKm)
            : base(fuel, consumptionPerKm + INCREASED_CONSUMPTION)
        {
        }
    }
}
