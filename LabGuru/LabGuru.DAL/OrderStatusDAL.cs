using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
    public class OrderStatusDAL : IOrderStatus
    {
        private readonly LabGuruDbContext db;

        public OrderStatusDAL(LabGuruDbContext db)
        {
            this.db = db;
        }
        public int AddOrderStatus(OrderStatus orderStatus)
        {
            using (db)
            {
                db.orderStatuses.Add(orderStatus);
                return db.SaveChanges();
            }
        }

        public List<OrderStatus> GetOrderStatuses(int OrderID)
        {
            using (db)
            {
                var result = db.orderStatuses.Where(w => w.OrderID == OrderID).ToList();
                return result;
            }
        }
    }
}
