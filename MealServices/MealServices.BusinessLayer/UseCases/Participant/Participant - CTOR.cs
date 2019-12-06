using MealServices.Shared.Interfaces;

using OnlineServices.Shared.MealServices;

using System;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class Participant : IMSParticipant
    {
        private IMSUnitOfWork UnitOfWork { get; }

        public Participant(IMSUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork ?? throw new ArgumentNullException(nameof(UnitOfWork));
        }

    }
}
