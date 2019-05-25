using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected ICollection<IAnimal> procedureHistory;

        protected Procedure() // TODO: May have to be ABSTRACT
        {
            this.procedureHistory = new List<IAnimal>();
        }

        public IEnumerable<IAnimal> ProcedureHistory //TODO: Setter not implemented, access to be made through methods and procedureHistory field directly changed
        {
            get { return procedureHistory; }
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);

            foreach (var animal in ProcedureHistory)
            {
                sb.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}"); //TODO: Not the same as what the final output looks like
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
    }
}
