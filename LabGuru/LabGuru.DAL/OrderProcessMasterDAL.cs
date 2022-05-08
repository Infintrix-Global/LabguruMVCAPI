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
        public ProcessMaster GetOrderProcessMaster(int id)
        {
            return dbContext.ProcessMasters.Where(w => w.id == id).FirstOrDefault();
        }

        public List<ProcessMaster> GetOrderProcessMasters()
        {
            return dbContext.ProcessMasters.ToList();
        }

        public int CreateOrderProcessMasters(ProcessMaster orderProcessMaster)
        {
            dbContext.ProcessMasters.Add(orderProcessMaster);
            return dbContext.SaveChanges();            
        }
    }
}
