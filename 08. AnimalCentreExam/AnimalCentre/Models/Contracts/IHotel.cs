﻿namespace AnimalCentre.Models.Contracts
{
    using AnimalCentre.Models.Animals;
    using System.Collections.Generic;

    public interface IHotel
    {
        int Capacity { get; }
        IReadOnlyDictionary<string,IAnimal> Animals { get; }
    }
}
