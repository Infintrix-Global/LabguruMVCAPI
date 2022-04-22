using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;

namespace LabGuru.DAL
{
    public class DoctorClinicDAL : IDoctorClinic
    {
        private readonly LabGuruDbContext dbContext;

        public DoctorClinicDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DoctorClinic GetDoctorClinic(int id)
        {
            try
            {
                return dbContext.DoctorClinics.Where(W=>W.id == id).FirstOrDefault();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            
        }

        public List<DoctorClinic> GetDoctorClinics(int UserID)
        {
            try
            {
                return dbContext.DoctorClinics.Where(w=>w.UserID == UserID).ToList();
            }
            catch (Exception exp)
            {

                throw new Exception(exp.Message);
            }
        }

        public int SetDefaultClinic(int DoctorID, int ClinicID)
        {
            var ClinitList = dbContext.DoctorClinics.Where(w => w.UserID == DoctorID).ToList();
            ClinitList.ForEach(e => e.isDefault = false);
            ClinitList.Where(w => w.id == ClinicID).ToList().ForEach(e => e.isDefault = true);
            return dbContext.SaveChanges();
        }
    }
}
