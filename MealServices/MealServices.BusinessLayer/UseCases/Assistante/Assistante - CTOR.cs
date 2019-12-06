using MealServices.Shared.Interfaces;

using OnlineServices.Shared.MealServices;

namespace MealServices.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante : Participant, IMSAssistanteSupplierManagement

    {
        public Assistante(IMSUnitOfWork iUnitOfWork) : base(iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork ?? throw new System.ArgumentNullException(nameof(iUnitOfWork));
        }

        public IMSUnitOfWork iUnitOfWork { get; }
    }
}
