using OnlineServices.Shared.AttendanceServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.AttendanceServices
{
    public interface IASAssistantRole
    {
        bool SetPresence(int formationID, int attendeeID, DateTime MomentPresence);
        AttendeePresenceTO GetAttendeePresence(int sessionID, int attendeeID);
        List<AttendeePresenceTO> GetSessionPresence(int sessionID); 
    }
}
