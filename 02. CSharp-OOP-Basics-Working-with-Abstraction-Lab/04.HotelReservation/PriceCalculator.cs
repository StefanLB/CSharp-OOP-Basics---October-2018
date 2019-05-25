using System;
using System.Collections.Generic;
using System.Text;

namespace _04.HotelReservation
{
    public class PriceCalculator
    {
        private decimal pricePerNight;
        private int numOfDays;
        private Season season;
        private DiscountType discount;

        public DiscountType Discount
        {
            get { return discount; }
            set { discount = value; }
        }


        public Season Season
        {
            get { return season; }
            set { season = value; }
        }

        public int NumOfDays
        {
            get { return numOfDays; }
            set { numOfDays = value; }
        }

        public decimal PricePerNight
        {
            get { return pricePerNight; }
            set { pricePerNight = value; }
        }


        public PriceCalculator(string input)
        {
            var tokens = input.Split();

            PricePerNight = decimal.Parse(tokens[0]);
            NumOfDays = int.Parse(tokens[1]);
            Season = Enum.Parse<Season>(tokens[2]);
            Discount = tokens.Length > 3 ?
                Enum.Parse<DiscountType>(tokens[3]) : DiscountType.None;
        }

        public decimal CalculatePrice()
        {
            var total = (PricePerNight * NumOfDays) * (int)Season;
            var discountPercent = ((decimal)100 - (int)discount) / 100;
            return total * discountPercent;
        }

    }
}
