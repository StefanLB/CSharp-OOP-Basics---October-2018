using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public double Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                this.width = value;
            }
        }

        public Rectangle(double height, double weight)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculatePerimeter()
        {
            return (Height + Width)*2;
        }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public sealed override string Draw()
        {
            return base.Draw() + $"Rectangle";
        }
    }
}
