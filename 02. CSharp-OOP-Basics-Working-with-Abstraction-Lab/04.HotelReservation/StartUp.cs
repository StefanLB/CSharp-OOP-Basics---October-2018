using System;

namespace _04.HotelReservation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            PriceCalculator priceCalc = new PriceCalculator(Console.ReadLine());
            var totalCost = priceCalc.CalculatePrice();
            Console.WriteLine(totalCost.ToString("F2"));
        }
    }
}
