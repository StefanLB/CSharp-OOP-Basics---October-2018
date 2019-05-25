using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _04.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
            private set { bagOfProducts = value; }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public void AddToBag(Product product)
        {
            if (product.Cost<=Money)
            {
                Money -= product.Cost;
                this.BagOfProducts.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (BagOfProducts.Count==0)
            {
                return $"{this.Name} - Nothing bought";
            }
            else
            {
                return $"{this.Name} - {string.Join(", ", BagOfProducts.Select(n => n.Name).ToList())}";
            }
        }
    }
}
