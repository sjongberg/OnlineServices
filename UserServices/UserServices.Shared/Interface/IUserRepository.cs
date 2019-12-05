using System;
using System.Collections.Generic;
using System.Text;

namespace UserServices.Shared.Interface
{
    interface IUserRepository
    {
        bool login();
        void logout();
    }
}
