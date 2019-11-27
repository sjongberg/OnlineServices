using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SandwichSystem.BusinessLayer;
using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.DataLayer;
using SandwichSystem.Shared;
using SandwichSystem.Shared.BTO;

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
