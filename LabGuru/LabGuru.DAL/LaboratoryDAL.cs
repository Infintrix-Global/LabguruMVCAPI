using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LabGuru.DAL
{
    public class LaboratoryDAL : ILaboratory
    {
        private readonly LabGuruDbContext dbContext;

        public LaboratoryDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int CreateLaboratoryUsers(Laboratory lab)
        {
            dbContext.Laboratories.Add(lab);
            int result = dbContext.SaveChanges();

            Login login = new Login();
            if (result > 0)
            {
                login.ReferanceID = lab.id;
                login.UserName = lab.LabName;
                string encryptedPassword = EncryptPassword((lab.LabName).Replace(" ","") + "@2022");

                login.Password = encryptedPassword;
                login.isActive = true;
                login.RoleID = "LAB";
                login.ReferanceType = BAL.Enums.LoginReference.Laboratory;
                login.IMEI = "Test";

                dbContext.Logins.Add(login);
                dbContext.SaveChanges();
                return lab.id;
            }
            else
            {
                return 0;
            }
        }

        public List<Laboratory> GetLaboratories()
        {
            return dbContext.Laboratories.ToList();
        }

        public Laboratory GetLaboratory(int id)
        {
            return dbContext.Laboratories.Where(w => w.id == id).FirstOrDefault();
        }


        public string EncryptPassword(string password)
        {
            string encryptPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return encryptPassword;
        }
    }
}
