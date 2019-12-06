using System.Collections.Generic;
using System.Linq;
using MealServices.BusinessLayer.Extensions;
using OnlineServices.Shared.MealServices.TransfertObjects;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class Participant
    {
        public List<MealTO> GetCurrentMenu()
        {
            var Supplier = UnitOfWork.SupplierRepository.GetDefaultSupplier();

            return UnitOfWork.MealRepository
                    .GetMealsBySupplier(Supplier)
                    .Select(x => x.ToDomain().ToTransfertObject())
                     .ToList();
        }
    }
}
