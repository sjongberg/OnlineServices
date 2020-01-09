using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.FacilityServices.Enumerations;
using System;

namespace OnlineServices.Shared.FacilityServices.TransfertObjects
{
    public class IncidentTO : IEntity<int>
    {
        public int Id { get; set; }
        public ComponentTO Component { get; set; }
        public IssueTO Issue { get; set; }
        public string Comment { get; set; }
        public DateTime SubmitDate { get; set; }
        public IncidentStatus Status { get; set; }
    }

}
