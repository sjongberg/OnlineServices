using System;

namespace AttendanceServices.BusinessLayer.Tests
{
    public class AssistantRole
    {
        private readonly INotificationServices notificationServices;

        public AssistantRole(INSNotificationServices notificationServices)
        {
            this.notificationServices = notificationServices;
        }

        public bool SendPresenceRapport(string email, DateTime startDate, DateTime endDate)
        {
            //1.Tester les entree

            //??? Logique metier Domain


            // SendNotification()

            //Domain to DAL
            notificationServices.Add();
            //return success failure

            throw new NotImplementedException();
        }
    }
}