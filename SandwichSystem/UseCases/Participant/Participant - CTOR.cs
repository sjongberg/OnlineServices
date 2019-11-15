using System;
using System.Collections.Generic;
using System.Text;
using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.DataLayer;

namespace SandwichSystem.BusinessLayer.UseCases
{
    public partial class Participant
    {
        public Participant(IRepository<Sandwich, int> SandwichRepo, IRepository<Ingredient, int> IngredientRepo)
        {
            if (SandwichRepo is null)
            {
                throw new ArgumentNullException(nameof(SandwichRepo));
            }
            if (IngredientRepo is null)
            {
                throw new ArgumentNullException(nameof(IngredientRepo));
            }

            this.SandwichRepo = SandwichRepo;
            this.IngredientRepo = IngredientRepo;
        }

        public IRepository<Sandwich, int> SandwichRepo { get; }
        public IRepository<Ingredient, int> IngredientRepo { get; }
    }
}
