using OnlineServices.Shared.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Shared.FacilityServices.Interfaces
{
    public interface IFSAttendeeRole
    {
        public bool CreateIncident(IncidentTO incidentTO, int attendeeId);
        public List<IncidentTO> GetIncidents();
        public List<IssueTO> GetIssues();
        public List<FloorTO> GetFloors();
        public List<RoomTO> GetRooms();
        public List<ComponentTO> GetComponents();
    }
}
