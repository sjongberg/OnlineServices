using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Shared.RegistrationServices.TransferObject;
using OnlineServices.Shared.DataAccessHelpers;

namespace OnlineServices.Shared.RegistrationServices.Interface
{
    public interface IRSSessionRepository : OnlineServices.Shared.DataAccessHelpers.IRepository<SessionTO, int>
    {
        IEnumerable<UserTO> GetStudents(SessionTO session);

        IEnumerable<DateTime> GetDates(SessionTO session);
    }
}