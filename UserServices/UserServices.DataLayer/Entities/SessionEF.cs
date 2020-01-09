﻿using OnlineServices.Shared.DataAccessHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistrationServices.DataLayer.Entities
{
    [Table("Session")]
    public class SessionEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public CourseEF Course { get; set; }
        //public Local Local { get; set; }
        public UserEF Teacher { get; set; }
        public ICollection<DateTime> Dates { get; set; }
        public ICollection<UserSessionEF> UserSessions { get; set; }
    }
}
