using OnlineServices.Shared.MealServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Shared.MealServices
{
    public interface IMSParticipant
    {
        List<MealTO> GetCurrentMenu();
    }
}