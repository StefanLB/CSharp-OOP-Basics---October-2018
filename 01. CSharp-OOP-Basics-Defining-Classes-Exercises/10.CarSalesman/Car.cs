using System;
using System.Collections.Generic;
using System.Text;

namespace _10.CarSalesman
{
    public class Car
    {
        //“<Model> <Engine> <Weight> <Color>”, 

        private string myVar;

        public string Model
        {
            get { return myVar; }
            set { myVar = value; }
        }

        private Engine engine;

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public override string ToString()
        {
            string displacement ="n/a";
            string efficiency = "n/a";
            string weightPrint = "n/a";
            string colorPrint = "n/a";

            if (Engine.Displacement>0)
            {
                displacement = Engine.Displacement.ToString();
            }

            if (Engine.Efficiency!=null)
            {
                efficiency = Engine.Efficiency;
            }

            if (Weight>0)
            {
                weightPrint = Weight.ToString();
            }

            if (Color!=null)
            {
                colorPrint = Color;
            }

            return $"{Model}:" + "\n" +
                   $"  {Engine.Model}:" + "\n" +
                   $"    Power: {Engine.Power}" + "\n" +
                   $"    Displacement: {displacement}" + "\n" +
                   $"    Efficiency: {efficiency}" + "\n" +
                   $"  Weight: {weightPrint}" + "\n" +
                   $"  Color: {colorPrint}" + "\n";
        }


    }
}
