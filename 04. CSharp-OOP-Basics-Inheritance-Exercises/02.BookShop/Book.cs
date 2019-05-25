using System;
using System.Collections.Generic;
using System.Text;

namespace _02.BookShop
{
    public class Book
    {
        private const int TITLE_MIN_LENGTH = 3;
        private string author;
        private string title;
        private decimal price;

        protected string Author
        {
            get { return author; }
            set
            {
                var splitNames = value.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (splitNames.Length > 1 && char.IsDigit(splitNames[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                this.author = value;
            }
        }

        protected string Title
        {
            get { return title; }
            set
            {
                if (value.Length < TITLE_MIN_LENGTH)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                price = value;
            }
        }

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }
    }
}
