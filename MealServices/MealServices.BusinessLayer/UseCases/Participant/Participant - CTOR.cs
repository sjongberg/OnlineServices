using System;
using MealServices.Shared.Interfaces;

namespace MealServices.BusinessLayer.UseCases
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
