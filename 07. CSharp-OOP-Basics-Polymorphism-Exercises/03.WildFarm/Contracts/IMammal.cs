using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Contracts
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
