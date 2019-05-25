using System;
using System.Collections.Generic;
using System.Text;

namespace _02.PointInRectangle
{
    public class Point
    {
        private int x;

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        private int y;

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
