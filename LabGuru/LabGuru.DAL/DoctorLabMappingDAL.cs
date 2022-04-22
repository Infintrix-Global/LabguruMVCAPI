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

        public List<DoctorLabMapping> Laboratorys(int ClinicID)
        {
            return db.DoctorLabMappings.Where(a => a.ClinicID == ClinicID).Select(s => new DoctorLabMapping
            {
                id = s.id,
                laboratory = s.laboratory,
                isDefault = s.isDefault
            }).ToList();
        }

        public int SetDefaultLab(int clinicID, int LabID)
        {
            var lblist = db.DoctorLabMappings.Where(w => w.ClinicID == clinicID).ToList();
            lblist.ForEach(e => e.isDefault =false);
            lblist.Where(w => w.LabID == LabID).ToList().ForEach(e => e.isDefault = true);
            return db.SaveChanges();
        }
    }
}
