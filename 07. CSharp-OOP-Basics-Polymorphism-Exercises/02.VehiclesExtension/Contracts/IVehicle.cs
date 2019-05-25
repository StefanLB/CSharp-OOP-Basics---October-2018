using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public interface IVehicle
    {
        double Fuel { get; }
        double ConsumptionPerKm { get; }
        double TankCapacity { get; }

        string Drive(double distance);
        void Refuel(double fuelAmount);
    }
}
