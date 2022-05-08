using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LabGuru.BAL.Enums;

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
                login.ReferanceType = BAL.Enums.LoginReference.LabAssitant;
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

        public int CreateLabEmployees(LabEmployee labEmployee)
        {
            dbContext.LabEmployees.Add(labEmployee);
            int result = dbContext.SaveChanges();
            dbContext.Dispose();

            Login login = new Login();
            if (result > 0 && (labEmployee.RoleID == (int)BAL.Enums.LoginReference.LabAssitant ||
                labEmployee.RoleID == (int)BAL.Enums.LoginReference.Admin ||
                labEmployee.RoleID == (int)BAL.Enums.LoginReference.Orthodontist))
            {
                login.ReferanceID = labEmployee.LabEmployeeID;
                login.UserName = labEmployee.UserName;
                string encryptedPassword = EncryptPassword((labEmployee.UserName).Replace(" ", "") + "@2022");

                var referenceType = BAL.Enums.LoginReference.Admin;
                if (labEmployee.RoleID == 2)
                    referenceType = BAL.Enums.LoginReference.LabAssitant;
                if (labEmployee.RoleID == 3)
                    referenceType = BAL.Enums.LoginReference.Admin;
                if (labEmployee.RoleID == 4)
                    referenceType = BAL.Enums.LoginReference.Orthodontist;

                login.Password = encryptedPassword;
                login.isActive = true;
                login.RoleID = Enum.GetName(typeof(LoginReference), labEmployee.RoleID);
                login.ReferanceType = referenceType;
                login.IMEI = "Test";

                dbContext.Logins.Add(login);
                dbContext.SaveChanges();
                dbContext.Dispose();

                return labEmployee.LabEmployeeID;
            }
            else
            {
                return 0;
            }
        }

        public string EncryptPassword(string password)
        {
            string encryptPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return encryptPassword;
        }
    }
}
