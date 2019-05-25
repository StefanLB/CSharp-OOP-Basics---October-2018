using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuel;
        private double consumptionPerKm;

        public double Fuel
        {
            get { return fuel; }
            protected set { this.fuel = value; }
        }

        public double ConsumptionPerKm
        {
            get { return consumptionPerKm; }
            protected set { this.consumptionPerKm = value; }
        }

        public Vehicle(double fuel, double consumptionPerKm)
        {
            this.Fuel = fuel;
            this.ConsumptionPerKm = consumptionPerKm;
        }

        public string Drive(double distance)
        {
            var consumption = this.consumptionPerKm;
            string msg = $"{this.GetType().Name} needs refueling";

            if (distance*consumption<=this.fuel)
            {
                msg = $"{this.GetType().Name} travelled {distance} km";
                this.fuel -= distance * consumption;
            }

            return msg;
        }

        public virtual void Refuel(double fuelAmount)
        {
            Fuel += fuelAmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Fuel:F2}";
        }
    }
}
