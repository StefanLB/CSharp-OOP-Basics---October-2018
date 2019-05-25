using System;
using System.Collections.Generic;
using System.Text;


    public class Car
    {
        private const double MaximumFuelCapacity = 160;

        private int hP;
        private double fuelAmount;
        private Tyre tyre;

        public int HP
        {
            get { return hP; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            private set
            {
                if (value>MaximumFuelCapacity)
                {
                    fuelAmount = MaximumFuelCapacity;
                }
                else if (value<0)
                {
                    throw new ArgumentException("Fuel amount cannot drop below zero"); //message was not requested
                }
                fuelAmount = value;
            }
        }

        public Tyre Tyre
        {
            get { return tyre; }
            private set { tyre = value; }
        }

        public Car(int hP, double fuelAmount,Tyre tyre)
    {
        this.hP = hP;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }
    }
