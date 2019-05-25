using System;
using System.Collections.Generic;
using System.Text;

namespace _08.RawData
{
    public class Engine
    {
        private int engineSpeed;

        public int EngineSpeed
        {
            get { return engineSpeed; }
            set { engineSpeed = value; }
        }

        private int enginePower;

        public int EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }

        public Engine(int engineSpeed, int enginePower)
        {
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
        }

        public Engine()
        {

        }
    }
}
