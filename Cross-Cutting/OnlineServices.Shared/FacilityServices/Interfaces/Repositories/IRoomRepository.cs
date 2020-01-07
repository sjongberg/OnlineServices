using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.FacilityServices.Interfaces.Repositories
{
    public interface IRoomRepository : IRepositoryTemp<RoomTO, int>
    {
        List<RoomTO> GetRoomsByFloors(FloorTO Floor);
    }
}
