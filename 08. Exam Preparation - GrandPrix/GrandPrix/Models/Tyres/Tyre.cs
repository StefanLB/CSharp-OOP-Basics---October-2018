using System;
using System.Collections.Generic;
using System.Text;


    public abstract class Tyre
    {
        private const double DefaultTyreDegradation = 100;

        private double hardness;
        private double degradation;

        public string Name { get; }

        public double Hardness { get; }

        public virtual double Degradation
        {
            get { return degradation; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Blown Tyre"); //Message was not requested
                }
                degradation = value;
            }
        }

        protected Tyre(string name, double hardness)
        {
            this.Degradation = DefaultTyreDegradation;
            this.Name = name;
            this.Hardness = hardness;
        }

    }
