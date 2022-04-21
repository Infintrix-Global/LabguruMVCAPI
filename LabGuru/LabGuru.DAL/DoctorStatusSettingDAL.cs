using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
    public class DoctorStatusSettingDAL : IDoctorStatusSetting
    {
        private readonly LabGuruDbContext db;

        public DoctorStatusSettingDAL(LabGuruDbContext db)
        {
            this.db = db;
        }
        public int AddOrderStatus(DoctorStatusSetting doctorStatus)
        {
            db.DoctorStatusSettings.Add(doctorStatus);
            return db.SaveChanges();
        }

        public List<DoctorStatusSetting> GetDoctorStatusSettings(int DoctorID, int LaboratoryID)
        {
            var result = (from DSS in db.DoctorStatusSettings
                          join Status in db.OrderStatusMasters on DSS.StatusMasterID equals Status.id
                          where Status.LaboratoryID == LaboratoryID &&
                                    DSS.LaboratoryID == LaboratoryID &&
                                    DSS.DoctorID == DoctorID
                          select new DoctorStatusSetting
                          {
                              id = DSS.id,
                              Include = DSS.Include,
                              //DoctorClinicID = DSS.DoctorClinicID,
                              LaboratoryID = DSS.LaboratoryID,
                              ShowToDoctor = DSS.ShowToDoctor,
                              StatusMaster = Status
                          }).OrderBy(o => o.StatusMaster.DispalyOrder).ToList();
            return result;
        }

        public bool isExistsOrderStatus(int DoctorID, int LaboraroryID, int StatusID)
        {
            return db.DoctorStatusSettings.Any(a => a.DoctorID == DoctorID && a.LaboratoryID == LaboraroryID && a.StatusMasterID == StatusID);

        }

        public int UpdateOrderStatus(DoctorStatusSetting doctorStatus)
        {
            var result = db.DoctorStatusSettings.Where(w => w.LaboratoryID == doctorStatus.LaboratoryID &&
            w.StatusMasterID == doctorStatus.StatusMasterID &&
            w.DoctorID == doctorStatus.DoctorID).FirstOrDefault();
            result.Include = doctorStatus.Include;
            result.ShowToDoctor = doctorStatus.ShowToDoctor;
            return db.SaveChanges();
        }


    }
}
