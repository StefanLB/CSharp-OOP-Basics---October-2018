using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Contracts
{
    interface IFeline : IMammal
    {
        string Breed { get; }
    }
}
