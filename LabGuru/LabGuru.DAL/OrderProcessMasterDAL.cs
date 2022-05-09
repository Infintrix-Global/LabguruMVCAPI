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

        public int CreateProductProcessEmployeeMapping(ProductProcessEmployee productProcessEmployee)
        {
            dbContext.ProductProcessEmployees.Add(productProcessEmployee);
            return dbContext.SaveChanges();            
        }
        public List<ProductProcessEmployee> GetProductProcessEmployee()
        {
            var Result = from ppe in dbContext.ProductProcessEmployees
                         join pt in dbContext.ProductTypes on ppe.ProductTypeID equals pt.ProductTypeID
                         join l in dbContext.Laboratories on ppe.LabID equals l.id
                         join le in dbContext.LabEmployees on ppe.LabEmployeeID equals le.LabEmployeeID
                         join pm in dbContext.ProcessMasters on ppe.ProcessID equals pm.id
                         select new ProductProcessEmployee
                         {
                             ProductProcessEmployeeID = ppe.ProductProcessEmployeeID,
                             ProcessID = ppe.ProcessID,
                             ProductTypeID = ppe.ProductTypeID,
                             LabID = ppe.LabID,
                             LabEmployeeID = ppe.LabEmployeeID,
                             ProductTypes = pt,
                             ProcessMasters = pm,
                             Laboratories = l,
                             LabEmployees = le
                         };

            return Result.OrderBy(s => s.ProcessMasters.ProcessName).ToList();
        }

    }
}
