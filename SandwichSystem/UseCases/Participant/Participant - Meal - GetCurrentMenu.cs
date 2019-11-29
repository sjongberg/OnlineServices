using System.Collections.Generic;
using System.Linq;
using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.Enumerations;
using SandwichSystem.Shared.TransfertObjects;

namespace SandwichSystem.BusinessLayer.UseCases
{
    public partial class Participant
    {
        //public List<SandwichBTO> GetCurrentMenu(Language Langue)
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
                    .GetSandwichesBySupplier(Supplier)
                    .Select(x => x.ToDomain().ToTransfertObject())
                     .ToList();
        }
    }
}
