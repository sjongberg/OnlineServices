using System;
using System.Collections.Generic;

namespace AttendanceServices.BusinessLayer.UseCases
{
    public class formationTemp
    {
        public int Id { get; set; }
        public List<DateTime> Jours { get; set; }
    }
}