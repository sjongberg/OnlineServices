using SandwichSystem.Shared.Interfaces;

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
