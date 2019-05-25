using System;
using System.Linq;

namespace _02.PointInRectangle
{
    public class Startup
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Rectangle rectangle = new Rectangle(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
            int inputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputs; i++)
            {
                int[] pointCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Point point = new Point(pointCoords[0], pointCoords[1]);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
