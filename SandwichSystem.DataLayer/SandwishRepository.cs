using SandwichSystem.DataLayer.Entities;
using SandwichSystem.DataLayer.Extentions;
using SandwichSystem.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.DataLayer
{
    public class SandwichRepository : IRepository<SandwichDTO, int>
    {
        public void Delete(SandwichDTO entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SandwichDTO> Get()
        {
            throw new NotImplementedException();
        }

        public SandwichDTO GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SandwichDTO entity)
        {
            using (var ctx = new SandwichContext())
            {
                ctx.Sandwiches.Add(entity.ToEF());

                ctx.SaveChanges();
            }
        }

        public void Update(SandwichDTO entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
