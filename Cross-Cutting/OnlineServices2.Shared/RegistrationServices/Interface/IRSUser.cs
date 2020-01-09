using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.RegistrationServices.Interface
{
    public interface IRSUser
    {
        int GetID();

        bool Login();

        void Logout();
    }
}