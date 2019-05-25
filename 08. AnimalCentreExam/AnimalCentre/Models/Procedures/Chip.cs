using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (!(animal.ProcedureTime>=procedureTime))
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
            if (animal.IsChipped) //ORDER OF CHECK -> PROCEDURE TIME OR OPERATION?
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.Happiness -= 5;
            animal.IsChipped = true;
            animal.ProcedureTime -= procedureTime;
            procedureHistory.Add(animal);
        }
    }
}
