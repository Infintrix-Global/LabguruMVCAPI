using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
    public class AuthenticationDAL : IAuthentication
    {
        private readonly LabGuruDbContext dbContext;

        public AuthenticationDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Authenticate(string Username, string Password)
        {
            var LoginUser = dbContext.Logins.FirstOrDefault(a => a.UserName == Username);
            if (LoginUser == null)
                return false;
            var isValid = BCrypt.Net.BCrypt.Verify(Password, LoginUser.Password);

            return isValid;
        }

        public Login GetLogin(string username)
        {
            var Loginuser = dbContext.Logins.Where(w => w.UserName == username).FirstOrDefault();
            if (Loginuser == null)
                throw new ArgumentException("Invalid User");
            //dbContext.Dispose();
            return Loginuser;
        }
    }
}
