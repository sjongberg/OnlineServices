using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.RegistrationServices.TransferObject
{
    public class SessionTO
    {
        public int ID { get; set; }
        public string Local { get; set; }
        public UserTO TeacherName { get; set; }
        public CourseTO Course { get; set; }
        public ICollection<UserTO> Attendees { get; set; }
    }
}
