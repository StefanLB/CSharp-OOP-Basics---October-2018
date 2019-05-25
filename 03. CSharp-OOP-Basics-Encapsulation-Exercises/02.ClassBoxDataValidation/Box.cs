using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxDataValidation
{
    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        private decimal Length
        {
            get { return this.length; }
            set
            {
                if (value<=0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    Environment.Exit(1);
                }
                else
                {
                    this.length = value;
                }
            }
        }

        private decimal Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    Environment.Exit(1);
                }
                else
                {
                    this.width = value;
                }
            }
        }

        private decimal Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    Environment.Exit(1);
                }
                else
                {
                    this.height = value;
                }
            }
        }

        public Box(decimal length, decimal width, decimal height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public decimal SurfaceArea()
        {
            return 2 * (length*width + width*height + height*length);
        }

        public decimal LateralSurfaceArea()
        {
            return 2 * (length * height + width * height);
        }

        public decimal Volume()
        {
            return length * width * height;
        }
    }
}
