﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OnlineServices.Shared.RegistrationServices.Interface
{
     public interface IRSAssistant
    {
        bool CreateUser();

        void DeleteUser();

        void CreateFromExcel(FileStream excelFile);
    }
}