using MealServices.BusinessLayer.Extensions;

using OnlineServices.Shared.MealServices.TransfertObjects;

using System.Collections.Generic;
using System.Linq;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public List<SupplierTO> GetSuppliers()
            => iMSUnitOfWork.SupplierRepository
                    .GetAll()
                    .Select(x => x.ToDomain().ToTransfertObject())
                    .ToList();
        //TODO Comment to students Try..Catch if not connected to db?
    }
}
