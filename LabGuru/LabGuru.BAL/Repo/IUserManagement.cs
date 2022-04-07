using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IUserManagement
    {
        Login GetUserProfile(int UserID);
    }
}
