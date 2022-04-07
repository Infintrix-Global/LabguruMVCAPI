using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LabGuru.DAL
{
    public class OrderProcessMasterDAL : IOrderProcessMaster
    {
        private readonly LabGuruDbContext dbContext;

        public OrderProcessMasterDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public OrderProcessMaster GetOrderProcessMaster(int id)
        {
            return dbContext.OrderProcessMasters.Where(w => w.id == id).FirstOrDefault();
        }

        public List<OrderProcessMaster> GetOrderProcessMasters()
        {
            return dbContext.OrderProcessMasters.ToList();
        }
    }
}
