﻿using MealServices.DataLayer.Extensions;

using Microsoft.EntityFrameworkCore;
using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.MealServices.TransfertObjects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MealServices.DataLayer.Repositories
{
    public class IngredientRepository : IRepositoryTemp<IngredientTO, int>
    {
        private readonly MealContext mealContext;

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
                throw;
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
            .Select(x => x.ToTranfertsObject())
            .ToList();

        public IngredientTO GetByID(int Id)
            => mealContext.Ingredients
            .Include(x => x.MealsWithIngredient)
                .ThenInclude(MealsWithIngredient => MealsWithIngredient.Meal)
                    .ThenInclude(Meal => Meal.MealsComposition)
                        .ThenInclude(MealsComposition => MealsComposition.Ingredient)
            .FirstOrDefault(x => x.Id == Id)
            .ToTranfertsObject();

        //TODO GetMealsByIngredient
        //public List<IngredientTO> GetMealsByIngredient(List<IngredientTO> Ingredients)
        //{
        //    throw new NotImplementedException();
        //}

        //TODO GetMealsWithoutIngredient
        //public List<IngredientTO> GetMealsWithoutIngredient(List<IngredientTO> Ingredients)
        //{
        //    throw new NotImplementedException();
        //}

        public IngredientTO Add(IngredientTO entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            return mealContext.Ingredients
                .Add(entity.ToEF())
                .Entity
                .ToTranfertsObject();
        }

        public IngredientTO Update(IngredientTO Entity)
        {
            if (Entity is null)
                throw new ArgumentNullException(nameof(Entity));

            return mealContext.Ingredients
                .Find(Entity.Id)
                .UpdateFromDetached(Entity.ToEF())
                .ToTranfertsObject();
        }
    }
}
