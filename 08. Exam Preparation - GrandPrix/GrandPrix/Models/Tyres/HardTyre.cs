using System;
using System.Collections.Generic;
using System.Text;


public class HardTyre : Tyre
{
    private const string NAME = "Hard";

    public HardTyre(double hardness)
        : base(NAME, hardness)
    {
    }
}
