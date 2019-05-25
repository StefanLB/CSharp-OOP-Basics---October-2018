using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }


        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Draws a hollow Rectangle with the specified width and height
        /// </summary>
        public void Draw()
        {
            DrawSolidLine();
            DrawHollowBody();
            DrawSolidLine();
        }

        public void DrawSolidLine()
        {
            Console.WriteLine(new string('*', Width));
        }

        public void DrawHollowBody()
        {
            for (int i = 1; i <= Height-2; i++)
            {
                Console.WriteLine("*" + new string(' ', (Width - 2)) + "*");
            }
        }
    }
}
