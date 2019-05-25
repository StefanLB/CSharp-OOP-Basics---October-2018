using System;
using System.Collections.Generic;
using System.Text;

namespace _02.PointInRectangle
{
    public class Rectangle
    {
        private Point topLeft;

        public Point TopLeft
        {
            get { return this.topLeft; }
            set { this.topLeft = value; }
        }

        private Point botRight;

        public Point BotRight
        {
            get { return this.botRight; }
            set { this.botRight = value; }
        }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            this.TopLeft = new Point(x1, y1);
            this.BotRight = new Point(x2, y2);
        }

        public Rectangle(Point topLeft,Point botRight)
        {
            this.TopLeft = topLeft;
            this.BotRight = botRight;
        }

        public bool Contains(Point point)
        {
            if ((TopLeft.X<=point.X && TopLeft.Y<=point.Y)&&
                (BotRight.X>=point.X && BotRight.Y>=point.Y))
            {
                return true;
            }
            return false;
        }

    }
}
