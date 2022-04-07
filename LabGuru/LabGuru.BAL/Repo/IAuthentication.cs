﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IAuthentication
    {
        bool Authenticat(string Username, string Password);
        Login GetLogin(string username);
    }
}
