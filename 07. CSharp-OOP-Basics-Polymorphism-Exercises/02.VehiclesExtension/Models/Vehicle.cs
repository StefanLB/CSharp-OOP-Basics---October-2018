using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public abstract class Vehicle : IVehicle
    {
        private double fuel;
        private double consumptionPerKm;
        private double tankCapacity;

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

        public double TankCapacity
        {
            get { return tankCapacity; }
            protected set { this.tankCapacity = value; }
        }

        public Vehicle(double fuel, double consumptionPerKm, double tankCapacity)
        {
            if (tankCapacity>=fuel)
            {
                this.Fuel = fuel;
            }
            else
            {
                this.Fuel = 0;
            }
            this.ConsumptionPerKm = consumptionPerKm;
            this.TankCapacity = tankCapacity;
        }

        public virtual string Drive(double distance, bool isAcOn)
        {
            var consumption = this.ConsumptionPerKm;

            string msg = $"{this.GetType().Name} needs refueling";

            if (distance * consumption <= this.Fuel)
            {
                msg = $"{this.GetType().Name} travelled {distance} km";
                this.Fuel -= distance * consumption;
            }

            return msg;
        }

        public virtual string Drive(double distance)
        {
            return Drive(distance, true);
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (fuelAmount+fuel>tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }
            Fuel += fuelAmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Fuel:F2}";
        }
    }
}
