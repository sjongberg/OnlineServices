using Microsoft.EntityFrameworkCore;
using MealServices.DataLayer.Extensions;
using MealServices.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MealServices.Shared.TransfertObjects;

namespace MealServices.DataLayer.Repositories
{
    public class IngredientRepository : IRepository<IngredientTO, int>
    {
        private MealContext mealContext;

        public IngredientRepository(MealContext ContextIoC)
        {
            mealContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in IngredientRepository");
        }

        public bool Remove(IngredientTO Entity)
        {
            try
            {
                mealContext.Ingredients.Remove(Entity.ToEF());
                return true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public bool Remove(int Id)
        {
            return Remove(GetByID(Id));
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

        public List<IngredientTO> GetMealsByIngredient(List<IngredientTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public List<IngredientTO> GetMealsWithoutIngredient(List<IngredientTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public IngredientTO Insert(IngredientTO entity)
            => mealContext.Ingredients
                .Add(entity.ToEF())
                .Entity
                .ToTranfertObject();

        public IngredientTO Update(IngredientTO Entity)
            => mealContext.Ingredients
                .Find(Entity.Id)
                .UpdateFromDetached(Entity.ToEF())
                .ToTranfertObject();
    }
}
