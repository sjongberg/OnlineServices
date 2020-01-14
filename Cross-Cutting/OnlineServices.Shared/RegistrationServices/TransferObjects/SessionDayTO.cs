using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.RegistrationServices.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.RegistrationServices.TransferObjects
{
    public class SessionDayTO : IEntity<int>
    {
        public int Id { get; set; }
        DateTime DaySession { get; set}
        SessionPresenceType PresenceType { get; set; }
    }
}
