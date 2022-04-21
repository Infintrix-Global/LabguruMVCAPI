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

    }
}
