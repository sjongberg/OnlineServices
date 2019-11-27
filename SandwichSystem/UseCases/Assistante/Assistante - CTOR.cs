using SandwichSystem.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SandwichSystem.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante : Participant
    {
        public Assistante(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}
