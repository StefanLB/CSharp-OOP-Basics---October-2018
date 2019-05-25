using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        public bool IsRunning { get; set; }

        public Engine()
        {
            this.IsRunning = true;
        }

        public void Run()
        {
            DungeonMaster dungeonMaster = new DungeonMaster();

            string command;

            while (this.IsRunning && !dungeonMaster.IsGameOver())
            {
                try
                {
                    command = Console.ReadLine();

                    if (string.IsNullOrEmpty(command))
                    {
                        this.IsRunning = false;
                        continue;
                    }
                    string commandArg = command.Split()[0];
                    string[] remainingArgs = command.Split().Skip(1).ToArray();

                    string result;
                    switch (commandArg)
                    {
                        case "JoinParty":
                            result = dungeonMaster.JoinParty(remainingArgs);
                            break;
                        case "AddItemToPool":
                            result = dungeonMaster.AddItemToPool(remainingArgs);
                            break;
                        case "PickUpItem":
                            result = dungeonMaster.PickUpItem(remainingArgs);
                            break;
                        case "UseItem":
                            result = dungeonMaster.UseItem(remainingArgs);
                            break;
                        case "UseItemOn":
                            result = dungeonMaster.UseItemOn(remainingArgs);
                            break;
                        case "GiveCharacterItem":
                            result = dungeonMaster.GiveCharacterItem(remainingArgs);
                            break;
                        case "GetStats":
                            result = dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            result = dungeonMaster.Attack(remainingArgs);
                            break;
                        case "Heal":
                            result = dungeonMaster.Heal(remainingArgs);
                            break;
                        case "EndTurn":
                            result = dungeonMaster.EndTurn(remainingArgs);
                            break;
                        case "IsGameOver":
                            result = dungeonMaster.IsGameOver().ToString();
                            break;
                        default:
                            result ="";
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Parameter Error: {ex.Message}");
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine($"Invalid Operation: {ex.Message}");
                }
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }
    }
}
