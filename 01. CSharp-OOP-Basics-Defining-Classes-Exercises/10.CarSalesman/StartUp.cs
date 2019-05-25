using System;
using System.Collections.Generic;

namespace _10.CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engines = new Dictionary<string, Engine>();
            var cars = new List<Car>();

            int numOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfEngines; i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries);
                GetEngine(tokens, engines);
            }

            int numOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCars; i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                GetCar(tokens, cars, engines);
            }

            foreach (var car in cars)
            {
                Console.Write(car.ToString());
            }
        }

        public static void GetCar(string[] tokens, List<Car> cars, Dictionary<string, Engine> engines)
        {
            //“<Model> <Engine> <Weight> <Color>”, 

            Car car = new Car();
            string model = tokens[0];
            Engine engine = new Engine();
            engine = engines[tokens[1]];
            int weight = 0;

            car.Model = model;
            car.Engine = engine;

            if (tokens.Length==4)
            {
                car.Weight = int.Parse(tokens[2]);
                car.Color = tokens[3];
            }
            else if (tokens.Length ==3)
            {
                if (int.TryParse(tokens[2], out weight))
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = tokens[2];
                }
            }

            cars.Add(car);
        }

        public static void GetEngine(string[] tokens, Dictionary<string, Engine> engines)
        {
            Engine engine = new Engine();
            string model = tokens[0];
            int power = int.Parse(tokens[1]);
            int displacement = 0;

            engine.Model = model;
            engine.Power = power;

            if (tokens.Length == 4)
            {
                engine.Displacement = int.Parse(tokens[2]);
                engine.Efficiency = tokens[3];
            }
            else if (tokens.Length == 3)
            {
                if (int.TryParse(tokens[2], out displacement))
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = tokens[2];
                }
            }

            engines.Add(model, engine);
        }
    }
}
