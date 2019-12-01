using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Extentions;
using SandwichSystem.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.DataLayer.Repositories
{
    public class IngredientRepository : IRepository<IngredientTO, int>
    {
        private MealContext mealContext;

        public IngredientRepository(MealContext ContextIoC)
        {
            mealContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in IngredientRepository");
        }

        public void Delete(IngredientTO Entity)
        {
            mealContext.Ingredients.Remove(Entity.ToEF());
        }

        public void Delete(int Id)
        {
            Delete(GetByID(Id));
        }

        public IEnumerable<IngredientTO> GetAll()
         => mealContext.Ingredients
            .Include(x => x.MealsWithIngredient)
                .ThenInclude(MealsWithIngredient => MealsWithIngredient.Meal)
                    .ThenInclude(Meal => Meal.MealsComposition)
                        .ThenInclude(MealsComposition => MealsComposition.Ingredient)
            .Select(x => x.ToTranfertObject())
            .ToList();

        public IngredientTO GetByID(int Id)
            => mealContext.Ingredients
            .Include(x => x.MealsWithIngredient)
                .ThenInclude(MealsWithIngredient => MealsWithIngredient.Meal)
                    .ThenInclude(Meal => Meal.MealsComposition)
                        .ThenInclude(MealsComposition => MealsComposition.Ingredient)
            .FirstOrDefault(x => x.Id == Id)
            .ToTranfertObject();

        public List<IngredientTO> GetSandwichesByIngredient(List<IngredientTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public List<IngredientTO> GetSandwichesWithoutIngredient(List<IngredientTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public void Insert(IngredientTO entity)
        {
            mealContext.Ingredients.Add(entity.ToEF());
        }

        public void Update(IngredientTO Entity)
        {
            throw new NotImplementedException();
        }
    }
}
