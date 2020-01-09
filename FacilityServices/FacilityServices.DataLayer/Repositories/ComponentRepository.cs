﻿using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.FacilityServices.Interfaces.Repositories;
using OnlineServices.Shared.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.DataLayer.Repositories
{
    internal class ComponentRepository : IComponentRepository
    {
        private FacilityContext facilityContext;

        public ComponentRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public ComponentTO Add(ComponentTO Entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ComponentTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ComponentTO GetByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<ComponentTO> GetComponentByRoom(RoomTO Room)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(ComponentTO entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new System.NotImplementedException();
        }

        public ComponentTO Update(ComponentTO Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}