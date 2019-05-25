using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double INCREASED_CONSUMPTION = 0.9;
        public Car(double fuel, double consumptionPerKm, double tankCapacity)
            : base(fuel, consumptionPerKm + INCREASED_CONSUMPTION, tankCapacity)
        {
        }
    }
}
