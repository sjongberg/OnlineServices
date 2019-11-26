using System;
using System.Collections.Generic;
using System.Text;
using SandwichSystem.BusinessLayer.Domain;
using SandwichSystem.DataLayer;

namespace SandwichSystem.BusinessLayer.UseCases
{
    public partial class Participant
    {
        public Participant(IUnitOfWork UnitOfWork)
        {
            if (UnitOfWork is null)
            {
                throw new ArgumentNullException(nameof(UnitOfWork));
            }

            this.UnitOfWork = UnitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}
