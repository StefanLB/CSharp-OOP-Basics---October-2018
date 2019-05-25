using System;
using System.Collections.Generic;
using System.Text;

namespace _07.SpeedRacing
{
    public class Car
    {
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private decimal fuelAmount;

        public decimal FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        private decimal fuelConsumptionPer1Km;

        public decimal FuelConsumptionPer1Km
        {
            get { return fuelConsumptionPer1Km; }
            set { fuelConsumptionPer1Km = value; }
        }

        private decimal distanceTraveled;

        public decimal DistanceTraveled
        {
            get { return distanceTraveled; }
            set { distanceTraveled = value; }
        }

        public Car(string model, decimal fuelAmount, decimal fuelConsumptionPer1Km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPer1Km = fuelConsumptionPer1Km;
            this.DistanceTraveled = 0;
        }

        public bool CarTravel(decimal distanceToDrive)
        {
            decimal possibleDistanceToDrive = (FuelAmount / FuelConsumptionPer1Km);

            if (possibleDistanceToDrive >= distanceToDrive)
            {
                DistanceTraveled += distanceToDrive;
                FuelAmount -= (distanceToDrive * FuelConsumptionPer1Km);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {DistanceTraveled:f0}";
        }

    }
}
