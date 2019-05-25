using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] safeContents = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < safeContents.Length; i += 2)
            {
                string foundGoods = safeContents[i];
                long goodsQuantity = long.Parse(safeContents[i + 1]);

                string typeOfGoods = string.Empty;

                CheckTypeOfGoods(ref typeOfGoods, foundGoods);

                if (typeOfGoods == "" || (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + goodsQuantity))
                {
                    continue;
                }

                bool fitsInBag = CheckIfFitsInBag(typeOfGoods,bag,goodsQuantity);

                if (fitsInBag)
                {
                    AddGoodsToBag(bag, typeOfGoods, foundGoods, goodsQuantity,ref gold,ref gems,ref cash);
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static void AddGoodsToBag(Dictionary<string, Dictionary<string, long>> bag, string typeOfGoods, string foundGoods,
            long goodsQuantity, ref long gold, ref long gems, ref long cash)
        {
            if (!bag.ContainsKey(typeOfGoods))
            {
                bag[typeOfGoods] = new Dictionary<string, long>();
            }

            if (!bag[typeOfGoods].ContainsKey(foundGoods))
            {
                bag[typeOfGoods][foundGoods] = 0;
            }

            bag[typeOfGoods][foundGoods] += goodsQuantity;
            if (typeOfGoods == "Gold")
            {
                gold += goodsQuantity;
            }
            else if (typeOfGoods == "Gem")
            {
                gems += goodsQuantity;
            }
            else if (typeOfGoods == "Cash")
            {
                cash += goodsQuantity;
            }
        }

        static bool CheckIfFitsInBag(string typeOfGoods, Dictionary<string, Dictionary<string, long>> bag, long goodsQuantity)
        {
            switch (typeOfGoods)
            {
                case "Gem":
                    if (!bag.ContainsKey(typeOfGoods))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (goodsQuantity > bag["Gold"].Values.Sum())
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (bag[typeOfGoods].Values.Sum() + goodsQuantity > bag["Gold"].Values.Sum())
                    {
                        return false;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(typeOfGoods))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (goodsQuantity > bag["Gem"].Values.Sum())
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (bag[typeOfGoods].Values.Sum() + goodsQuantity > bag["Gem"].Values.Sum())
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        static void CheckTypeOfGoods(ref string typeOfGoods, string foundGoods)
        {
            if (foundGoods.Length == 3)
            {
                typeOfGoods = "Cash";
            }
            else if (foundGoods.ToLower().EndsWith("gem"))
            {
                typeOfGoods = "Gem";
            }
            else if (foundGoods.ToLower() == "gold")
            {
                typeOfGoods = "Gold";
            }
        }
    }
}