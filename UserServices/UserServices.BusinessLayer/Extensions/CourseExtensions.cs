using System;
using System.Collections.Generic;
using System.Text;
using OnlineServices.Shared.RegistrationServices.TransferObject;

namespace RegistrationServices.BusinessLayer.Extensions
{
    public static class CourseExtensions
    {
        public static Course ToDomain(this CourseTO courseTO)
        {
            return new Course
            {
                ID = courseTO.ID,
                Name = courseTO.Name,
            };
        }

        public  static CourseTO ToTransferObject(this Course course)
        {
            return new CourseTO
            {
                ID = course.ID,
                Name = course.Name,
            };
        }
    }
}
