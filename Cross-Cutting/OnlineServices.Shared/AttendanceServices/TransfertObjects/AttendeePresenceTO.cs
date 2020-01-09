using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.AttendanceServices.TransfertObjects
{
    public class AttendeePresenceTO
    {
        public int attendeeID;
        public int sessionID;
        public int localID;
        public List<DateTime> PresenceDay;

    }
}
