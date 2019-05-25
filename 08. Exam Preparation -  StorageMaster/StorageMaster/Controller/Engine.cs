using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Controller
{
    public class Engine
    {
        private StorageMaster storageMaster;
        private bool isRunning;

        public Engine(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
            this.isRunning = true;
        }

        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = command.Split();
                    string commandResult;

                    switch (tokens[0])
                    {
                        case "AddProduct":
                            commandResult = storageMaster.AddProduct(tokens[1], double.Parse(tokens[2]));
                            break;
                        case "RegisterStorage":
                            commandResult = storageMaster.RegisterStorage(tokens[1], tokens[2]);
                            break;
                        case "SelectVehicle":
                            commandResult = storageMaster.SelectVehicle(tokens[1], int.Parse(tokens[2]));
                            break;
                        case "LoadVehicle":
                            commandResult = storageMaster.LoadVehicle(tokens.Skip(1));
                            break;
                        case "SendVehicleTo":
                            commandResult = storageMaster.SendVehicleTo(tokens[1], int.Parse(tokens[2]), tokens[3]);
                            break;
                        case "UnloadVehicle":
                            commandResult = storageMaster.UnloadVehicle(tokens[1], int.Parse(tokens[2]));
                            break;
                        case "GetStorageStatus":
                            commandResult = storageMaster.GetStorageStatus(tokens[1]);
                            break;
                        default:
                            continue;
                    }

                    Console.WriteLine(commandResult);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            this.isRunning = false;
            string result = this.storageMaster.GetSummary();
            Console.WriteLine(result);
        }
    }
}
