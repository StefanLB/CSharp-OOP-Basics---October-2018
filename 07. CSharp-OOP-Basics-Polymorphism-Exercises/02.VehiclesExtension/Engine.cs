using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Engine
    {
        public void Run()
        {
            var vehicles = new List<Vehicle>();

            var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(double.Parse).ToArray();
            vehicles.Add(new Car(tokens[0], tokens[1], tokens[2]));
            tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(double.Parse).ToArray();
            vehicles.Add(new Truck(tokens[0], tokens[1], tokens[2]));
            tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(double.Parse).ToArray();
            vehicles.Add(new Bus(tokens[0], tokens[1], tokens[2]));

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] commandTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandTokens[0];
                string vehicleType = commandTokens[1];

                var vehicle = vehicles.First(v => v.GetType().Name == vehicleType);

                if (action == "Drive")
                {
                    DriveVehicle(vehicle, commandTokens[2]);
                }
                else if (action == "Refuel")
                {
                    RefuelVehicle(vehicle, commandTokens[2]);
                }
                else if (action == "DriveEmpty")
                {
                    double distance = double.Parse(commandTokens[2]);
                    string result = vehicle.Drive(distance, false);
                    Console.WriteLine(result);
                }
            }

            vehicles.ForEach(v => Console.WriteLine(v));
        }

        private void RefuelVehicle(Vehicle vehicle, string litersToken)
        {
            double liters = double.Parse(litersToken);
            try
            {
                vehicle.Refuel(liters);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DriveVehicle(Vehicle vehicle, string distanceToken)
        {
            double distance = double.Parse(distanceToken);

            string result = vehicle.Drive(distance);
            Console.WriteLine(result);
        }
    }
}
