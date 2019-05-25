using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double INCREASED_CONSUMPTION = 1.4;
        public Bus(double fuel, double consumptionPerKm, double tankCapacity)
            :base(fuel, consumptionPerKm, tankCapacity)
        {
        }

        public override string Drive(double distance, bool isAcOn)
        {
            var consumption = this.ConsumptionPerKm;

            if (isAcOn)
            {
                consumption += INCREASED_CONSUMPTION;
            }

            if (distance*consumption<=this.Fuel)
            {
                this.Fuel -= distance * consumption;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }
    }
}
