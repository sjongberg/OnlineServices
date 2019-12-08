using OnlineServices.Shared.MealServices;
using OnlineServices.Shared.MealServices.Interfaces;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class AssistantRole : AttendeeRole, IMSAssistantRole
    {
        private readonly IMSUnitOfWork iMSUnitOfWork;

        public AssistantRole(IMSUnitOfWork iMSUnitOfWork) : base(iMSUnitOfWork)
        {
            this.iMSUnitOfWork = iMSUnitOfWork ?? throw new System.ArgumentNullException(nameof(iMSUnitOfWork));
        }
    }
}
