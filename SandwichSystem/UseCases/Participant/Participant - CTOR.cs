using System;
using SandwichSystem.Shared.Interfaces;

namespace SandwichSystem.BusinessLayer.UseCases
{
    public partial class Participant
    {
        private IUnitOfWork UnitOfWork { get; }

        public Participant(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork ?? throw new ArgumentNullException(nameof(UnitOfWork));
        }

    }
}
