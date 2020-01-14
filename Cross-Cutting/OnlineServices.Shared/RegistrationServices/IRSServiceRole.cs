using OnlineServices.Shared.RegistrationServices.TransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.RegistrationServices
{
    public interface IRSServiceRole
    {
        bool IsInSession(int userId, int sessionId);
        List<UserTO> GetUserInSession(int sessionId);
    }
}