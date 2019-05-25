using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var familyTree = new List<Person>();
            string personInput = Console.ReadLine();
            Person mainPerson = new Person();

            if (IsBirthday(personInput))
            {
                mainPerson.Birthday = personInput;
            }
            else
            {
                mainPerson.Name = personInput;
            }

            familyTree.Add(mainPerson);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");
                if (tokens.Length > 1)
                {
                    string firstPerson = tokens[0];
                    string secondPerson = tokens[1];

                    Person currentPerson;

                    if (IsBirthday(firstPerson))
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person();
                            currentPerson.Birthday = firstPerson;
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondPerson);
                    }
                    else
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Name == firstPerson);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person();
                            currentPerson.Name = firstPerson;
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondPerson);
                    }
                }
                else
                {
                    tokens = command.Split();
                    string name = tokens[0] + " " + tokens[1];
                    string birthday = tokens[2];

                    var persons = familyTree
                        .Where(p =>
                        (p.Name == name) || p.Birthday == birthday)
                        .ToList();

                    var children = new List<Person>();
                    var parents = new List<Person>();

                    foreach (var person in persons)
                    {
                        children.AddRange(person.Children);
                        parents.AddRange(person.Parents);
                    }

                    foreach (var person in persons)
                    {
                        person.Name = name;
                        person.Birthday = birthday;
                        person.Children = children;
                        person.Parents = parents;
                    }
                }
            }

            Console.WriteLine(mainPerson.ToString());
        }

        private static void SetChild(List<Person> familyTree, Person parentPerson, string child)
        {
            var childPerson = new Person();

            if (IsBirthday(child))
            {
                if (!familyTree.Any(p => p.Birthday == child))
                {
                    childPerson.Birthday = child;
                    familyTree.Add(childPerson);
                }
                else
                {
                    childPerson = familyTree.First(p => p.Birthday == child);
                }
            }
            else
            {
                if (!familyTree.Any(p => p.Name == child))
                {
                    childPerson.Name = child;
                    familyTree.Add(childPerson);
                }
                else
                {
                    childPerson = familyTree.First(p => p.Name == child);
                }
            }

            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
        }

        static bool IsBirthday(string input)
        {
            return Char.IsDigit(input[0]);
        }
    }
}
