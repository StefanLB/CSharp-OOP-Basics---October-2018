using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.RectangleInsertion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var rectangles = new List<Rectangle>();

            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numOfRec = tokens[0];
            int numOfChecks = tokens[1];

            for (int i = 0; i < numOfRec; i++)
            {
                string[] recTokens = Console.ReadLine().Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries);
                string id = recTokens[0];
                double width = double.Parse(recTokens[1]);
                double height = double.Parse(recTokens[2]);
                double topLeftCol = double.Parse(recTokens[3]);
                double topLeftRow = double.Parse(recTokens[4]);

                Rectangle rectangle = new Rectangle(id, width, height, topLeftCol, topLeftRow);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < numOfChecks; i++)
            {
                string[] recsToCompare = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                Rectangle rec1 = rectangles.Where(x => x.Id == recsToCompare[0]).First();
                Rectangle rec2 = rectangles.Where(x => x.Id == recsToCompare[1]).First();

                Console.WriteLine(rec1.IntersectCheck(rec2).ToString().ToLower());
            }
        }
    }
}
