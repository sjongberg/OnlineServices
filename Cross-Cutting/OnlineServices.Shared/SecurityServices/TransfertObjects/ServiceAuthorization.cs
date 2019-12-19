using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.SecurityServices.TransfertObjects
{
    public class ServiceAuthorization
    {
        public Guid ServiceGuid { get; set; }
        public Guid AuthorizationToken { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
