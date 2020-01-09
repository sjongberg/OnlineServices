using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.DataAccessHelpers
{
    public interface IEntity<TIdType>
    {
        TIdType Id { get; set; }
    }
}
