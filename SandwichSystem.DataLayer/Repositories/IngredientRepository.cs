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
        private SandwichSystemContext Context;

        public IngredientRepository(SandwichSystemContext ContextInjected)
        {
            Context = ContextInjected ?? throw new ArgumentNullException(nameof(ContextInjected));
        }

        public void Delete(IngredientTO Entity)
        {
            Context.Ingredients.Remove(Entity.ToEF());
        }

        public void Delete(int Id)
        {
            Delete(GetByID(Id));
        }

        public IEnumerable<IngredientTO> GetAll()
         => Context.Ingredients
            .Include(x => x.SandwichIngredients)
            .Select(x => x.ToTranfertObject()).ToList();

        public IngredientTO GetByID(int Id)
            => Context.Ingredients
            .Include(x => x.SandwichIngredients)
            .FirstOrDefault(x => x.Id == Id).ToTranfertObject();

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
            Context.Ingredients.Add(entity.ToEF());
        }

        public void Update(IngredientTO Entity)
        {
            throw new NotImplementedException();
        }
    }
}
