using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.FamilyTree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var firstPersonInfo = Console.ReadLine().Split();
            var familyTree = new List<Person>();

            if (firstPersonInfo.Length == 1)
            {
                familyTree.Add(new Person(firstPersonInfo[0]));
            }
            else if (firstPersonInfo.Length == 2)
            {
                familyTree.Add(new Person(firstPersonInfo[0], firstPersonInfo[1]));
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    if (!familyTree.Any(p => p.BirthDate == tokens[0]))
                    {
                        familyTree.Add(new Person(tokens[0]));
                    }

                    var parent = familyTree.First(p => p.BirthDate == tokens[0]);

                    if (!familyTree.Any(p => p.BirthDate == tokens[1]))
                    {
                        familyTree.Add(new Person(tokens[1]));
                    }

                    var child = familyTree.First(p => p.BirthDate == tokens[1]);

                    parent.AddChild(child);
                    child.AddParent(parent);
                }
                else if (tokens.Length == 3)
                {
                    if (command.Contains("-"))
                    {
                        if (Char.IsDigit(tokens[0][0]))
                        {
                            if (!familyTree.Any(p => p.BirthDate == tokens[0]))
                            {
                                familyTree.Add(new Person(tokens[0]));
                            }

                            var parent = familyTree.First(p => p.BirthDate == tokens[0]);

                            if (!familyTree.Any(p => p.FirstName == tokens[1] && p.LastName == tokens[2]))
                            {
                                familyTree.Add(new Person(tokens[1], tokens[2]));
                            }

                            var child = familyTree.First(p => p.FirstName == tokens[1] && p.LastName == tokens[2]);

                            parent.AddChild(child);
                            child.AddParent(parent);
                        }
                        else if (Char.IsDigit(tokens[2][0]))
                        {
                            if (!familyTree.Any(p => p.BirthDate == tokens[2]))
                            {
                                familyTree.Add(new Person(tokens[2]));
                            }

                            var child = familyTree.First(p => p.BirthDate == tokens[2]);

                            if (!familyTree.Any(p => p.FirstName == tokens[0] && p.LastName == tokens[1]))
                            {
                                familyTree.Add(new Person(tokens[0], tokens[1]));
                            }

                            var parent = familyTree.First(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);

                            parent.AddChild(child);
                            child.AddParent(parent);
                        }
                    }
                    else
                    {
                        var persons = familyTree
                            .Where(p =>
                            (p.FirstName == tokens[0] && p.LastName == tokens[1]) || p.BirthDate == tokens[2])
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
                            person.FirstName = tokens[0];
                            person.LastName = tokens[1];
                            person.BirthDate = tokens[2];
                            person.Children = children;
                            person.Parents = parents;
                        }
                    }
                }
                else if (tokens.Length == 4)
                {
                    if (!familyTree.Any(p => p.FirstName == tokens[0] && p.LastName == tokens[1]))
                    {
                        familyTree.Add(new Person(tokens[0], tokens[1]));
                    }

                    var parent = familyTree.First(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);

                    if (!familyTree.Any(p => p.FirstName == tokens[2] && p.LastName == tokens[3]))
                    {
                        familyTree.Add(new Person(tokens[2], tokens[3]));
                    }

                    var child = familyTree.First(p => p.FirstName == tokens[2] && p.LastName == tokens[3]);

                    parent.AddChild(child);
                    child.AddParent(parent);
                }
            }

            Person target = null;
            if (firstPersonInfo.Length == 1)
            {
                target = familyTree.First(p => p.BirthDate == firstPersonInfo[0]);
            }
            else if (firstPersonInfo.Length == 2)
            {
                target = familyTree.First(p => p.FirstName == firstPersonInfo[0] && p.LastName == firstPersonInfo[1]);
            }

            Console.WriteLine(target);
        }
    }
}
