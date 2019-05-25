using AnimalCentre.Models.Animals;
using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        IEnumerable<IAnimal> ProcedureHistory { get; } // TODO: May have to be a ReadOnlyCollection/List or LIST

        string History();

        void DoService(IAnimal animal, int procedureTime);
    }
}
