using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public interface IVehicle
    {
        double Fuel { get; }
        double ConsumptionPerKm { get; }

        string Drive(double distance);
        void Refuel(double fuelAmount);
    }
}
