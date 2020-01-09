using System.Collections.Generic;

namespace AttendanceServices.BusinessLayer.UseCases
{

    //utiliser le vrais UserServices
    public interface IUserServicesTemp
    {
        IEnumerable<int> GetFormationAttendes(int sessionID);
        formationTemp GetFormation(int sessionID);
    }
}