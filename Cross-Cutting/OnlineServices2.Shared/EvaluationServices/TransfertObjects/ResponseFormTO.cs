using OnlineServices.Shared.DataAccessHelpers;
using System.Collections.Generic;

namespace OnlineServices.Shared.EvaluationServices
{
    public class ResponseFormTO<T> : IEntity<int>
    {
        public int Id { get; set; }

        public int SessionID { get; set; }
        public int FormID { get; set; }
        public int AttendeeID { get; set; }

        public List<ResponseOpenTO> Response { get; set; }
    }
}