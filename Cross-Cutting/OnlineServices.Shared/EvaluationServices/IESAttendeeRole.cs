using OnlineServices.Shared.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.EvaluationServices
{
    public interface IESAttendeeRole
    {
        FormTO GetForm(int sessionID, int FormModelID);
        //bool SetResponse<T>(int sessionID, ResponseFormTO<T> response);
    }
}
