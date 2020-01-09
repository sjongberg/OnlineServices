using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.FacilityServices.Interfaces.Repositories
{
    public interface IIncidentRepository : IRepositoryTemp<IncidentTO, int>
    {
        List<IncidentTO> GetIncidentsByUserId(int UserId);
        //Est-ce que nous ne rajouterions pas DateTime pour les Incidents, comme ça on pourrait faire un tri par date ? 
    }
}
