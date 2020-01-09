using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsSameDate (this DateTime jourExtended, DateTime jourToCompare)
        {
            
            return ((jourExtended.Year == jourToCompare.Year)&&
                (jourExtended.Month == jourToCompare.Month) &&
                (jourExtended.Day == jourToCompare.Day));
        }
    }
}
