using _09.CollectionHierarchy.Models;
using System;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var addColl = new AddCollection();
            var addRemColl = new AddRemoveCollection();
            var myList = new MyList();

            string[] input = Console.ReadLine().Split();
            int elementsToDiscard = int.Parse(Console.ReadLine());

            AddInputToLists(addColl, addRemColl, myList, input);
            RemoveElementsFromLists(addRemColl, myList, elementsToDiscard);
        }

        static void RemoveElementsFromLists(AddRemoveCollection addRemColl, MyList myList, int elementsToDiscard)
        {
            var sbAddRemColl = new StringBuilder();
            var sbMyList = new StringBuilder();

            for (int i = 0; i < elementsToDiscard; i++)
            {
                sbAddRemColl.Append(addRemColl.Remove() + " ");
                sbMyList.Append(myList.Remove() + " ");
            }

            Console.WriteLine(sbAddRemColl.ToString().Trim());
            Console.WriteLine(sbMyList.ToString().Trim());
        }

        static void AddInputToLists(AddCollection addColl, AddRemoveCollection addRemColl, MyList myList, string[] input)
        {
            var sbAddColl = new StringBuilder();
            var sbAddRemColl = new StringBuilder();
            var sbMyList = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                string token = input[i];
                sbAddColl.Append(addColl.Add(token) + " ");
                sbAddRemColl.Append(addRemColl.Add(token) + " ");
                sbMyList.Append(myList.Add(token) + " ");
            }

            Console.WriteLine(sbAddColl.ToString().Trim());
            Console.WriteLine(sbAddRemColl.ToString().Trim());
            Console.WriteLine(sbMyList.ToString().Trim());
        }
    }
}
