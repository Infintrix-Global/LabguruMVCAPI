using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
    public class OrderStatusMasterDAL : IOrderStatusMaster
    {
        private readonly LabGuruDbContext db;
        public OrderStatusMasterDAL(LabGuruDbContext db)
        {
            this.db = db;
        }
        public int CreateOrderStatus(OrderStatusMaster orderStatusMaster)
        {
            db.OrderStatusMasters.Add(orderStatusMaster);
            return db.SaveChanges();
        }

        public List<OrderStatusMaster> GetOrderStatusMasters(int LabID)
        {
            return db.OrderStatusMasters.Where(w => w.LaboratoryID == LabID).OrderBy(o=>o.DispalyOrder).ToList();
        }

        public bool isStatusExists(int LabID, string StatusText)
        {
            return db.OrderStatusMasters.Any(w => w.LaboratoryID == LabID && w.StatusText == StatusText);
        }

        public List<DoctorStatusSetting> GetDoctorStatus(int labID, int DoctorID)
        {
          return  (from DSS in db.DoctorStatusSettings
             join Status in db.OrderStatusMasters on DSS.StatusMasterID equals Status.id
             where Status.LaboratoryID == labID &&
                       DSS.DoctorID == DoctorID && DSS.Include && DSS.ShowToDoctor
             select new DoctorStatusSetting
             {
                 id = DSS.id,
                 Include = DSS.Include,
                 LaboratoryID = DSS.LaboratoryID,
                 ShowToDoctor = DSS.ShowToDoctor,
                 StatusMaster = Status
             }).OrderBy(o => o.StatusMaster.DispalyOrder).ToList();
        }

    }
}
