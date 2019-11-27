using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Extentions;
using SandwichSystem.Shared.Interfaces;
using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SandwichSystem.DataLayer.Repositories
{
    public class SandwichRepository : ISandwichRepository
    {
        private SandwichSystemContext Context;

        public SandwichRepository(SandwichSystemContext ContextInjected)
        {
            Context = ContextInjected ?? throw new ArgumentNullException(nameof(ContextInjected));
        }

        public void Delete(SandwichDTO entityToDelete)
        {
            Context.Sandwiches.Remove(entityToDelete.ToEF());
        }

        public void Delete(int id)
        {
            Delete(GetByID(id));
        }

        public IEnumerable<SandwichDTO> GetAll()
         => Context.Sandwiches
            .Include(x => x.Supplier)
            .Include(x => x.SandwichIngredients)
            .Select(x => x.ToDTO()).ToList();

        public SandwichDTO GetByID(int id)
            => Context.Sandwiches
            .Include(x => x.Supplier)
            .Include(x => x.SandwichIngredients)
            .FirstOrDefault(x => x.Id == id).ToDTO();

        public List<SandwichDTO> GetSandwichesByIngredient(List<IngredientDTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public List<SandwichDTO> GetSandwichesBySupplier(SupplierDTO Supplier)
            => Context.Sandwiches
            .Include(x => x.Supplier)
            .Include(x => x.SandwichIngredients)
            .Where(x=>x.Supplier.Id == Supplier.Id)
            .Select(x=>x.ToDTO())
            .ToList();

        public List<SandwichDTO> GetSandwichesWithoutIngredient(List<IngredientDTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public void Insert(SandwichDTO entity)
        {
            Context.Sandwiches.Add(entity.ToEF());
        }

        public void Update(SandwichDTO entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
