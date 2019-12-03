using System.Collections.Generic;
using System.Linq;
using MealServices.BusinessLayer.Extensions;
using MealServices.Shared.Enumerations;
using MealServices.Shared.TransfertObjects;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class Participant
    {
        //public List<MealTO> GetCurrentMenu(Language Langue)
        //{ 
        //    var Supplier = UnitOfWork.SupplierRepository.GetCurrentSupplier();

        //    return UnitOfWork.SandwichRepository
        //            .GetSandwichesBySupplier(Supplier)
        //            .Select(x => x.ToDomain().ToBTO(Langue))
        //             .ToList();
        //}

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
