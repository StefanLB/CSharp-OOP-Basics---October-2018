using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBox
{
    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        public Box(decimal length, decimal width, decimal height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
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
