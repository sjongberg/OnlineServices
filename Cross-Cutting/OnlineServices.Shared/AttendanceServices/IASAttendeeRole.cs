using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.AttendanceServices
{
    public interface IASAttendeeRole
    {
        bool SetPresence(int formationID, int attendeeID);
    }
}
