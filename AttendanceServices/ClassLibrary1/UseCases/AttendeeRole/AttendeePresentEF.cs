using System;

namespace AttendanceServices.BusinessLayer.UseCases
{
    //Move to DataLayer
    public class AttendeePresentEF
    {
        public int AttendeeID { get; set; }
        public int FormationID { get; set; }
        public DateTime Presence { get; set; }
    }
}