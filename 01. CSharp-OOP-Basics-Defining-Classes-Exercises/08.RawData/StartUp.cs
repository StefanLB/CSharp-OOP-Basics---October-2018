using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                double tire1Pressure = double.Parse(tokens[5]);
                int tire1Age = int.Parse(tokens[6]);
                double tire2Pressure = double.Parse(tokens[7]);
                int tire2Age = int.Parse(tokens[8]);
                double tire3Pressure = double.Parse(tokens[9]);
                int tire3Age = int.Parse(tokens[10]);
                double tire4Pressure = double.Parse(tokens[11]);
                int tire4Age = int.Parse(tokens[12]);

                Engine engine = new Engine(engineSpeed,enginePower);
                Cargo cargo = new Cargo(cargoWeight,cargoType);
                Tire tire1 = new Tire(tire1Pressure, tire1Age);
                Tire tire2 = new Tire(tire2Pressure, tire2Age);
                Tire tire3 = new Tire(tire3Pressure, tire3Age);
                Tire tire4 = new Tire(tire4Pressure, tire4Age);

                Car car = new Car(model, engine, cargo, tire1, tire2, tire3, tire4);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            List<Car> filteredCars = new List<Car>();

            if (command == "fragile")
            {
                filteredCars = cars.Where(c => c.Cargo.CargoType == "fragile").ToList();
                foreach (var car in filteredCars)
                {
                    for (int i = 0; i < car.Tires.Count(); i++)
                    {
                        if (car.Tires[i].TirePressure<1)
                        {
                            Console.WriteLine(car.Model);
                            break;
                        }
                    }
                }
            }
            else
            {
                filteredCars = cars.Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250).ToList();

                Console.WriteLine(string.Join("\n", filteredCars.Select(c => c.Model)));
            }
        }
    }
}
