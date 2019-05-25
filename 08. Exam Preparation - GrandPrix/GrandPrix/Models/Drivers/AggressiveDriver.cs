using System;
using System.Collections.Generic;
using System.Text;


    public class AggressiveDriver : Driver
    {
        private const double AggressiveFuelConsumptionPerKm = 2.7;
        private const double AgressiveSpeedMultiplier = 1.3;
        public AggressiveDriver(string name, Car car)
            : base(name, car, AggressiveFuelConsumptionPerKm)
        {
        }

        public override double Speed => base.Speed* AgressiveSpeedMultiplier;
    }
