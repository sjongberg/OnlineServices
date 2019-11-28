using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Extentions;
using SandwichSystem.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.DataLayer.Repositories
{
    public class SandwichRepository : ISandwichRepository
    {
        private SandwichSystemContext Context;

        public SandwichRepository(SandwichSystemContext ContextInjected)
        {
            Context = ContextInjected ?? throw new ArgumentNullException(nameof(ContextInjected));
        }

        public void Delete(Shared.TransfertObjects.SandwichTO Entity)
        {
            Context.Sandwiches.Remove(Entity.ToEF());
        }

        public void Delete(int Id)
        {
            Delete(GetByID(Id));
        }

        public IEnumerable<Shared.TransfertObjects.SandwichTO> GetAll()
         => Context.Sandwiches
            .Include(x => x.Supplier)
            .Include(x => x.SandwichIngredients)
            .Select(x => x.ToTranfertObject()).ToList();

        public SandwichTO GetByID(int Id)
            => Context.Sandwiches
            .Include(x => x.Supplier)
            .Include(x => x.SandwichIngredients)
            .FirstOrDefault(x => x.Id == Id).ToTranfertObject();

        public List<Shared.TransfertObjects.SandwichTO> GetSandwichesByIngredient(List<IngredientTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public List<Shared.TransfertObjects.SandwichTO> GetSandwichesBySupplier(SupplierTO Supplier)
            => Context.Sandwiches
            .Include(x => x.Supplier)
            .Include(x => x.SandwichIngredients)
            .Where(x=>x.Supplier.Id == Supplier.Id)
            .Select(x=>x.ToTranfertObject())
            .ToList();

        public List<Shared.TransfertObjects.SandwichTO> GetSandwichesWithoutIngredient(List<IngredientTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public void Insert(Shared.TransfertObjects.SandwichTO Entity)
        {
            Context.Sandwiches.Add(Entity.ToEF());
        }

        public void Update(Shared.TransfertObjects.SandwichTO Entity)
        {
            throw new NotImplementedException();
        }
    }
}
