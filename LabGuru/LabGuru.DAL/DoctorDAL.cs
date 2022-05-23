using LabGuru.BAL;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LabGuru.BAL.Repo;

namespace LabGuru.DAL
{
    public class DoctorDAL : IDoctor
    {
        private readonly LabGuruDbContext dbContext;

        public DoctorDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int CreateDoctors(DoctorDetails doctorDetails)
        {
            dbContext.DoctorDetails.Add(doctorDetails);
            int result = dbContext.SaveChanges();

            Login login = new Login();
            if (result > 0)
            {
                login.ReferanceID = doctorDetails.DoctorDetailsID;
                login.UserName = doctorDetails.UserName;
                string encryptedPassword = EncryptPassword((doctorDetails.UserName).Replace(" ", "") + "@2022");

                login.Password = encryptedPassword;
                login.isActive = true;
                login.RoleID = 1;
                //login.ReferanceType = BAL.Enums.LoginReference.Doctor;
                login.IMEI = "Test";

                dbContext.Logins.Add(login);
                dbContext.SaveChanges();
                return doctorDetails.DoctorDetailsID;
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

        public DoctorDetails GetDoctorDetails(int DoctorDetailsID)
        {
            var Doctor = dbContext.DoctorDetails.Where(w => w.DoctorDetailsID == DoctorDetailsID).FirstOrDefault();
            if (Doctor == null)
                throw new ArgumentException("Invalid Doctor");
            return Doctor;
        }
        public List<DoctorDetails> GetDoctorDetails()
        {
            return dbContext.DoctorDetails.OrderBy(o=>o.FirstName).ToList();
        }
    }
}
