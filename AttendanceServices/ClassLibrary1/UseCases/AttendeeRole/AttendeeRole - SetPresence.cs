using AttendanceServices.BusinessLayer.Domain;
using OnlineServices.Shared.AttendanceServices;
using OnlineServices.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceServices.BusinessLayer.UseCases
{
    public partial class AttendeeRole : IASAttendeeRole
    {
        public bool SetPresence(int formationID, int attendeeID)
        {
            if(!userServices.GetFormationAttendes(formationID).Any(x=> x == attendeeID))
                throw new Exception("Attendee do not exist in formation");
            if (!userServices.GetFormation(formationID).Jours.Any(x => x.IsSameDate(DateTime.Now)))
                throw new Exception("Not a formation day");
            try
            {


                var presence = new AttendeePresentEF
                {
                    FormationID = formationID,
                    AttendeeID = attendeeID,
                    Presence = DateTime.Now
                };

                if (!presenceRepository.Insert(presence))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
    }
}
