using _08.MilitaryElite.Interfaces;
using _08.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MilitaryElite
{
    public class StartUp
    {
        public static List<Private> allPrivates = new List<Private>();

        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine())!="End")
            {
                var tokens = input.Split();
                var type = tokens[0];
                var func = FindTypeSoldierToCreate(type);
                func(tokens);
            }
        }

        static Action<string[]> FindTypeSoldierToCreate(string type)
        {
            switch (type)
            {
                case "Private": return CreatePrivate;
                case "Spy": return CreateSpy;
                case "Commando": return CreateCommando;
                case "Engineer": return CreateEngineer;
                case "LieutenantGeneral": return CreateLieutenantGeneral;
                default: throw new ArgumentException();
            }
        }

        static void CreatePrivate(string[] tokens)
        {
            Private prv = new Private(tokens[1], tokens[2], tokens[3], double.Parse(tokens[4]));
            allPrivates.Add(prv);
            Print(prv);
        }

        static void CreateSpy(string[] tokens)
        {
            Spy spy = new Spy(tokens[1], tokens[2], tokens[3], int.Parse(tokens[4]));
            Print(spy);
        }

        static void CreateCommando(string[] tokens)
        {
            List<IMission> missions = new List<IMission>();
            for (int i = 6; i < tokens.Length; i+=2)
            {
                try
                {
                    missions.Add(new Mission(tokens[i], tokens[i + 1]));
                }
                catch (Exception) { }
            }

            try
            {
                Commando cmd = new Commando(tokens[1],
                    tokens[2],
                    tokens[3],
                    double.Parse(tokens[4]),
                    tokens[5],
                    missions);

                Print(cmd);
            }
            catch (Exception) { }
        }

        static void CreateEngineer(string[] tokens)
        {
            List<IRepair> repairs = new List<IRepair>();
            for (int i = 6; i < tokens.Length; i += 2)
            {
                repairs.Add(new Repair(tokens[i], int.Parse(tokens[i + 1])));
            }

            try
            {
                Engineer eng = new Engineer(tokens[1],
                    tokens[2],
                    tokens[3],
                    double.Parse(tokens[4]),
                    tokens[5],
                    repairs);

                Print(eng);
            }
            catch (Exception) { }
        }

        static void CreateLieutenantGeneral(string[] tokens)
        {
            List<IPrivate> privates = new List<IPrivate>();
            for (int i = 5; i < tokens.Length; i++)
            {
                var priv = allPrivates.FirstOrDefault(p => p.Id == tokens[i]);
                privates?.Add(priv);
            }
            LieutenantGeneral lieutenant = new LieutenantGeneral(tokens[1],
                tokens[2],
                tokens[3],
                double.Parse(tokens[4]),
                privates);

            Print(lieutenant);
        }

        static void Print(Soldier soldier)
        {
            Console.WriteLine(soldier);
        }
    }
}
