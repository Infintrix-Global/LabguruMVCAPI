using LabGuru.BAL;
using LabGuru.BAL.Component;
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

        public bool isExistsLab(int DoctorID, int LabID)
        {
            return db.DoctorLabMappings.Any(a => a.DoctorID == DoctorID && a.LabID == LabID);
        }

        public List<DoctorLabMapping> Laboratorys(int DoctorID)
        {
            return db.DoctorLabMappings.Where(a => a.DoctorID == DoctorID).Select(s => new DoctorLabMapping
            {
                id = s.id,
                laboratory = s.laboratory,
                isDefault = s.isDefault
            }).ToList();
        }

        public int SetDefaultLab(int DoctorID, int LabID)
        {
            var lblist = db.DoctorLabMappings.Where(w => w.DoctorID == DoctorID).ToList();
            lblist.ForEach(e => e.isDefault =false);
            lblist.Where(w => w.LabID == LabID).ToList().ForEach(e => e.isDefault = true);
            return db.SaveChanges();
        }

        public List<DoctorLapMappings> GetDoctorLapMapping()
        {
            var LabEmployee = from dm in db.DoctorLabMappings
                              join dd in db.DoctorDetails on dm.DoctorID equals dd.DoctorDetailsID
                              join l in db.Laboratories on dm.LabID equals l.id
                              select new DoctorLapMappings
                              {
                                  DoctorLapMappingID = dm.id,
                                  LabID = l.id,
                                  DoctorID = dd.DoctorDetailsID,
                                  DoctorName = dd.FirstName + " " + dd.LastName,
                                  LabName = l.LabName
                              };

            return LabEmployee.ToList();
        }
    }
}
