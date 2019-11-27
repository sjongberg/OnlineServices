using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.BTO;
using System.Collections.Generic;
using System.Linq;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante
    {
        public List<SupplierBTO> GetSuppliers()
            => UnitOfWork.SupplierRepository
                    .GetAll()
                    .Select(x => x.ToDomain().ToBTO())
                    .ToList();
        //TODO Comment to students Try..Catch if not connected to db?
    }
}
