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
