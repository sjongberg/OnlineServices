using OnlineServices.Shared.FacilityServices.Interfaces.Repositories;
using OnlineServices.Shared.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.DataLayer.Repositories
{
    internal class IssueRepository : IIssueRepository
    {
        private FacilityContext facilityContext;

        public IssueRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public IssueTO Add(IssueTO Entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IssueTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IssueTO GetByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(IssueTO entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IssueTO Update(IssueTO Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}