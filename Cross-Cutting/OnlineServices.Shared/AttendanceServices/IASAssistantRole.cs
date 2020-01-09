using OnlineServices.Shared.AttendanceServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.AttendanceServices
{
    public interface IASAssistantRole
    {
        bool SetPresence(AttendeePresenceTO presenceTO);
        List<AttendeePresenceTO> GetAttendeePresence(int formationID, int attendeeID);
        List<AttendeePresenceTO> GetFormationPresence(int formationID); 
    }
}
