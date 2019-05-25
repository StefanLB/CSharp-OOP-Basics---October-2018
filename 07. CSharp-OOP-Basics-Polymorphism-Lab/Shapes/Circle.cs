using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get
            {
                return this.radius;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                this.radius = value;
            }
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public sealed override string Draw()
        {
            return base.Draw() + $"Circle";
        }
    }
}
