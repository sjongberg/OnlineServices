using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.RegistrationServices.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.RegistrationServices.TransferObject
{
    public class SessionTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public UserTO TeacherName { get; set; }
        public CourseTO Course { get; set; }
        public List<SessionDayTO>  SessionDays{ get; set; }
        public List<UserTO> Attendees { get; set; }
    }
}
