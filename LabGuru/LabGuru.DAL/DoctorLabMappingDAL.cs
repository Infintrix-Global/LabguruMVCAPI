using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
   public class DoctorLabMappingDAL : IDoctorLabMapping
    {
        private readonly LabGuruDbContext db;

        public DoctorLabMappingDAL(LabGuruDbContext db)
        {
            this.db = db;
        }
        public int AddClinicLab(DoctorLabMapping doctorLabMapping)
        {
            db.DoctorLabMappings.Add(doctorLabMapping);
            return db.SaveChanges();
        }

        public bool isExistsLab(int ClinicID, int LabID)
        {
            return db.DoctorLabMappings.Any(a => a.ClinicID == ClinicID && a.LabID == LabID);
        }

        public List<Laboratory> Laboratorys(int ClinicID)
        {
            return db.DoctorLabMappings.Where(a => a.ClinicID == ClinicID).Select(S=>S.laboratory).ToList();
        }
    }
}
