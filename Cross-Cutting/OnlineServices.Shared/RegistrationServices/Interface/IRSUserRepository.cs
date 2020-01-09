using OnlineServices.Shared.DataAccessHelpers;
using System.Collections.Generic;
using OnlineServices.Shared.RegistrationServices.TransferObject;

namespace OnlineServices.Shared.RegistrationServices.Interface 
{ 
     public interface IRSUserRepository : IRepository<UserTO, int>
    {
        IEnumerable<SessionTO> GetSessions(UserTO user);

        IEnumerable<UserTO> GetByRole(UserRole role);

        IEnumerable<UserTO> GetBySession(SessionTO session);

        bool IsInSession(UserTO user, SessionTO session);
    }
}