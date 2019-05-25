using System;
using System.Collections.Generic;
using System.Text;

namespace _02.BookShop
{
    public class GoldenEditionBook : Book
    {
        public override decimal Price
        {
            get { return base.Price * 1.30m; }
        }

        public GoldenEditionBook(string author, string title, decimal price)
            :base(author,title,price)
        {
        }
    }
}
