using OnlineServices.Shared.FacilityServices.Interfaces.Repositories;
using OnlineServices.Shared.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.DataLayer.Repositories
{
    internal class RoomRepository : IRoomRepository
    {
        private FacilityContext facilityContext;

        public RoomRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public RoomTO Add(RoomTO Entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RoomTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public RoomTO GetByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(RoomTO entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new System.NotImplementedException();
        }

        public RoomTO Update(RoomTO Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}