using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SandwichSystem.BusinessLayer;
using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.BusinessLayer.Extentions;
using SandwichSystem.Shared.BTO;

namespace SandwichSystem.BusinessLayer.UseCases
{
    public partial class Participant
    {
        public List<SandwichBTO> AfficherMenu(string Founisseur, Language Langue)
            => SandwichRepo.Get()
                .Select(x=> x.ToBTO(Langue))
                .ToList();

        public List<IngredientBTO> DisplayIngredients(string sandwich, Language Langue)
            => IngredientRepo.Get()
                .Select(x => x.ToBTO(Langue))
                .ToList();

    }
}
