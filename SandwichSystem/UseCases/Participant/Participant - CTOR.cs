using System;
using System.Collections.Generic;
using System.Text;
using SandwichSystem.DataLayer;

namespace SandwichSystem.BusinessLayer.UseCases
{
    public partial class Participant
    {
        public Participant(IRepository<Sandwish, int> SandwishRepo, IRepository<Ingredient, int> IngredientRepo)
        {
            if (SandwishRepo is null)
            {
                throw new ArgumentNullException(nameof(SandwishRepo));
            }
            if (IngredientRepo is null)
            {
                throw new ArgumentNullException(nameof(IngredientRepo));
            }

            this.SandwishRepo = SandwishRepo;
            this.IngredientRepo = IngredientRepo;
        }

        public IRepository<Sandwish, int> SandwishRepo { get; }
        public IRepository<Ingredient, int> IngredientRepo { get; }
    }
}
