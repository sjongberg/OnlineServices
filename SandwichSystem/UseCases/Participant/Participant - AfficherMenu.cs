using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SandwichSystem.BusinessLayer;

namespace SandwichSystem.BusinessLayer.UseCases
{
    public partial class Participant
    {
        public List<Sandwish> AfficherMenu(string Founisseur, Language Langue)
        {
            return SandwishRepo.Get().ToList();
        }
    }
}
