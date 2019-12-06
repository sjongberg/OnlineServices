using MealServices.BusinessLayer.Extensions;

using OnlineServices.Shared.MealServices.TransfertObjects;

using System.Collections.Generic;
using System.Linq;

namespace MealServices.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public List<SupplierTO> GetSuppliers()
            => iUnitOfWork.SupplierRepository
                    .GetAll()
                    .Select(x => x.ToDomain().ToTransfertObject())
                    .ToList();
        //TODO Comment to students Try..Catch if not connected to db?
    }
}
