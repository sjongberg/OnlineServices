using Microsoft.EntityFrameworkCore;
using SandwichSystem.DataLayer.Entities;
using SandwichSystem.DataLayer.Extentions;
using SandwichSystem.DataLayer.Interfaces;
using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SandwichSystem.DataLayer.Repositories
{
    public class IngredientRepository : IRepository<IngredientDTO,int>
    {
        private SandwichSystemContext Context;

        public IngredientRepository(SandwichSystemContext ContextInjected)
        {
            Context = ContextInjected ?? throw new ArgumentNullException(nameof(ContextInjected));
        }

        public void Delete(IngredientDTO entityToDelete)
        {
            Context.Ingredients.Remove(entityToDelete.ToEF());
        }

        public void Delete(int id)
        {
            Delete(GetByID(id));
        }

        public IEnumerable<IngredientDTO> GetAll()
         => Context.Ingredients
            .Include(x => x.SandwichIngredients)
            .Select(x => x.ToDTO()).ToList();

        public IngredientDTO GetByID(int id)
            => Context.Ingredients
            .Include(x => x.SandwichIngredients)
            .FirstOrDefault(x => x.Id == id).ToDTO();

        public List<IngredientDTO> GetSandwichesByIngredient(List<IngredientDTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public List<IngredientDTO> GetSandwichesWithoutIngredient(List<IngredientDTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public void Insert(IngredientDTO entity)
        {
            Context.Ingredients.Add(entity.ToEF());
        }

        public void Update(IngredientDTO entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
