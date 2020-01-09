using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Shared.Extensions;


namespace RegistrationServices.BusinessLayer
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public bool IsValid()
        {
            Name.IsNullOrWhiteSpace("Course Name should not be empty nor whitespaces");

            return true;
        }
    }
}
