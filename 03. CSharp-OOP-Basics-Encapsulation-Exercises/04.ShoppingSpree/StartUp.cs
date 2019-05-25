using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleTokens = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
            string[] productsTokens = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);

            var people = new List<Person>();
            var products = new List<Product>();

            PopulatePeople(peopleTokens, people);
            PopulateProducts(productsTokens,products);

            string command = Console.ReadLine();

            while (command!="END")
            {
                string person = command.Split()[0];
                string product = command.Split()[1];

                FillBags(people, products, person, product);

                command = Console.ReadLine();
            }

            people.ForEach(x => Console.WriteLine(x.ToString()));
        }

        private static void FillBags(List<Person> people, List<Product> products, string person, string product)
        {
            try
            {
                people.Where(x => x.Name == person).FirstOrDefault().AddToBag(products.Where(x => x.Name == product).FirstOrDefault());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PopulateProducts(string[] productsTokens, List<Product> products)
        {
            for (int i = 0; i < productsTokens.Length; i ++)
            {
                string productName = productsTokens[i].Split('=',StringSplitOptions.RemoveEmptyEntries)[0];
                decimal productPrice = decimal.Parse(productsTokens[i].Split('=', StringSplitOptions.RemoveEmptyEntries)[1]);

                try
                {
                    Product product = new Product(productName, productPrice);
                    products.Add(product);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }
            }
        }

        private static void PopulatePeople(string[] peopleTokens, List<Person> people)
        {
            for (int i = 0; i < peopleTokens.Length; i ++)
            {
                string personName = peopleTokens[i].Split('=', StringSplitOptions.RemoveEmptyEntries)[0];
                decimal personMoney = decimal.Parse(peopleTokens[i].Split('=', StringSplitOptions.RemoveEmptyEntries)[1]);

                try
                {
                    Person person = new Person(personName, personMoney);
                    people.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }
            }
        }
    }
}
