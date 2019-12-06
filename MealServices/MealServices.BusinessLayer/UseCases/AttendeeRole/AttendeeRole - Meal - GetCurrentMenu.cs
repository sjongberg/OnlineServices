using MealServices.BusinessLayer.Extensions;

using OnlineServices.Shared.MealServices.TransfertObjects;

using System.Collections.Generic;
using System.Linq;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole
    {
        public List<MealTO> GetCurrentMenu()
        {
            var Supplier = iMSUnitOfWork.SupplierRepository.GetDefaultSupplier();

            return iMSUnitOfWork.MealRepository
                    .GetMealsBySupplier(Supplier)
                    .Select(x => x.ToDomain().ToTransfertObject())
                     .ToList();
        }
    }
}
