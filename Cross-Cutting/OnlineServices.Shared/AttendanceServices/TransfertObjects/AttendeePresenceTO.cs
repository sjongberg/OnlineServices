using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.AttendanceServices.TransfertObjects
{
    public class AttendeePresenceTO
    {
        public int attendeeID;
        public int sessionID;
        public int localID;  //TODO a revoir si necessaire
        public List<DateTime> PresenceDay;

    }
}
