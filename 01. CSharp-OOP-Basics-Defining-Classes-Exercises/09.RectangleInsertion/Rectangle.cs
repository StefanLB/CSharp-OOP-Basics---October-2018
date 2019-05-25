using System;
using System.Collections.Generic;
using System.Text;

namespace _09.RectangleInsertion
{
    public class Rectangle
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private double width;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        private double height;

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        private double topLeftRow;

        public double TopLeftRow
        {
            get { return topLeftRow; }
            set { topLeftRow = value; }
        }

        private double topLeftCol;

        public double TopLeftCol
        {
            get { return topLeftCol; }
            set { topLeftCol = value; }
        }

        public Rectangle(string id, double width, double height, double topLeftCol, double topLeftRow)
        {
            Id = id;
            Width = width;
            Height = height;
            TopLeftRow = topLeftRow;
            TopLeftCol = topLeftCol;
        }

        public bool IntersectCheck(Rectangle rec2)
        {
            if (rec2.TopLeftRow > TopLeftRow+Height || rec2.TopLeftCol>TopLeftCol+Width
                || rec2.TopLeftRow + rec2.Height<TopLeftRow || rec2.TopLeftCol+rec2.Width<TopLeftCol)
            {
                return false;
            }
            else if ((TopLeftRow < rec2.TopLeftRow && TopLeftCol < rec2.TopLeftCol) &&
                ((TopLeftRow + Height) > (rec2.TopLeftRow + rec2.Height) && (TopLeftCol + Width) > (rec2.TopLeftCol + rec2.Width)))
            {
                return false;
            }

            return true;
            //if (!((TopLeftRow <= rec2.TopLeftRow && TopLeftCol <= rec2.TopLeftCol) &&
            //    ((TopLeftRow + Height) >= rec2.TopLeftRow && (TopLeftCol + Width) >= rec2.TopLeftCol)))
            //{
            //    return false;
            //}
            //else if (!((TopLeftRow <= (rec2.TopLeftRow + rec2.Height) && TopLeftCol <= (rec2.TopLeftCol + rec2.Width)) &&
            //    ((TopLeftRow + Height) >= (rec2.TopLeftRow + rec2.Height) && (TopLeftCol + Width) >= (rec2.TopLeftCol + rec2.Width))))
            //{
            //    return false;
            //}
            //else if ((TopLeftRow < rec2.TopLeftRow && TopLeftCol < rec2.TopLeftCol) &&
            //    ((TopLeftRow + Height) > (rec2.TopLeftRow + rec2.Height) && (TopLeftCol + Width) > (rec2.TopLeftCol + rec2.Width)))
            //{
            //    return false;
            //}
        }
    }
}
