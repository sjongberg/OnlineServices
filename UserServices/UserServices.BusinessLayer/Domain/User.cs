using System;
using OnlineServices.Shared.Extensions;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace RegistrationServices.BusinessLayer
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public List<Session> Sessions { get; set; } = new List<Session>();
        //public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public bool IsActivated { get; set; }


        public bool IsValid()
        {
            Name.IsNullOrWhiteSpace("User Name should not be empty nor whitespaces");

            return true;
        }

        public bool ValidateEmail(string mail)
        {
            var regex = @"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]";
            bool isValid = Regex.IsMatch(mail, regex, RegexOptions.IgnoreCase);
            return isValid;
        }
    }


}
