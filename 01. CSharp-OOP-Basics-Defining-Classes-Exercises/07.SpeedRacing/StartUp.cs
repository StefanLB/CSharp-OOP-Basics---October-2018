using System;
using System.Collections.Generic;

namespace _07.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cars = new Dictionary<string, Car>();

            int carsToTrack = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsToTrack; i++)
            {
                //“<Model> <FuelAmount> <FuelConsumptionFor1km>
                string[] tokens = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                decimal fuelAmount = decimal.Parse(tokens[1]);
                decimal fuelConsumptionPer1Km = decimal.Parse(tokens[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPer1Km);

                cars.Add(model, car);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine())!="End")
            {
                string[] tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[1];
                decimal distanceToDrive = decimal.Parse(tokens[2]);

                if (!cars[model].CarTravel(distanceToDrive))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (Car car in cars.Values)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
