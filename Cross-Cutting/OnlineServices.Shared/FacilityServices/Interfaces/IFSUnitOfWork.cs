﻿using OnlineServices.Shared.FacilityServices.Interfaces.Repositories;
using System;

namespace OnlineServices.Shared.FacilityServices.Interfaces
{
    public interface IFSUnitOfWork : IDisposable
    {
        IComponentRepository ComponentRepository { get; }
        IFloorRepository FloorRepository { get; }
        IIssueRepository IssueRepository { get; }
        IRoomRepository RoomRepository { get; }
        IIncidentRepository IncidentRepository { get; }

        void Save();
    }
}
