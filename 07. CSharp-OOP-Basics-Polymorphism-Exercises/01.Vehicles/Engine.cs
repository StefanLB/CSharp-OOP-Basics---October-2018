using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuel = double.Parse(carInfo[1]);
            double carConsumptionsPerKm = double.Parse(carInfo[2]);

            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumptionPerKm = double.Parse(truckInfo[2]);

            int numOfCommands = int.Parse(Console.ReadLine());

            Vehicle car = new Car(carFuel, carConsumptionsPerKm);
            Vehicle truck = new Truck(truckFuel, truckConsumptionPerKm);

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] commandTokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string action = commandTokens[0];
                string vehicleType = commandTokens[1];

                if (action == "Drive")
                {
                    DriveVehicle(car,truck,commandTokens[2],vehicleType);
                }
                else if (action == "Refuel")
                {
                    RefuelVehicle(car, truck, commandTokens[2],vehicleType);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }

        private void RefuelVehicle(Vehicle car, Vehicle truck, string litersToken, string vehicleType)
        {
            double liters = double.Parse(litersToken);

            if (vehicleType == "Car")
            {
                car.Refuel(liters);
            }
            else if (vehicleType == "Truck")
            {
                truck.Refuel(liters);
            }
        }

        private void DriveVehicle(Vehicle car, Vehicle truck, string distanceToken, string vehicleType)
        {
            double distance = double.Parse(distanceToken);

            if (vehicleType == "Car")
            {
                string result = car.Drive(distance);
                Console.WriteLine(result);
            }
            else if (vehicleType == "Truck")
            {
                string result = truck.Drive(distance);
                Console.WriteLine(result);
            }
        }
    }
}
