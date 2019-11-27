using System.Collections.Generic;
using System.Linq;
using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.BTO;
using SandwichSystem.Shared.Enumerations;

namespace SandwichSystem.BusinessLayer.UseCases
{
    public partial class Participant
    {
        public List<SandwichBTO> GetCurrentMenu(Language Langue)
        { 
            var Supplier = UnitOfWork.SupplierRepository.GetCurrentSupplier();

            return UnitOfWork.SandwichRepository
                    .GetSandwichesBySupplier(Supplier)
                    .Select(x => x.ToDomain().ToBTO(Langue))
                     .ToList();
        }
    }
}
