using System;
using System.Collections.Generic;
using System.Text;


public class UltrasoftTyre : Tyre
{
    private double grip;

    public double Grip
    {
        get { return grip; }
        private set { grip = value; }
    }

    private const string NAME = "Ultrasoft";

    public override double Degradation
    {
        get
        {
            return base.Degradation;
        }
        set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre"); //Message was not requested
            }
            base.Degradation = value;
        }
    }

    public UltrasoftTyre(double hardness, double grip)
        : base(NAME, hardness)
    {
        this.Grip = grip;
    }
}
