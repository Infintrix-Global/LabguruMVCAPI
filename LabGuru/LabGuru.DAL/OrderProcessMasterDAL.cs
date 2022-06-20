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
            var res = from PM in dbContext.ProcessMasters
                      join PT in dbContext.ProductTypes on PM.ProductID equals PT.ProductTypeID
                      select new ProcessMaster
                      {
                          id = PM.id,
                          ProcessName = PM.ProcessName,
                          ProductID = PM.ProductID,
                          productType = PT
                      };
            return res.ToList();
        }

        public List<ProcessMaster> GetOrderProcessByLabId(int labId)
        {
            var result = from ppe in dbContext.ProductProcessEmployees
                         join pm in dbContext.ProcessMasters on ppe.ProcessID equals pm.id
                         join pt in dbContext.ProductTypes on pm.ProductID equals pt.ProductTypeID
                         where ppe.LabID == labId
                         select new ProcessMaster
                         {
                             id = pm.id,
                             ProcessName = pm.ProcessName,
                             ProductID = pm.ProductID,
                             productType = pt
                         };
            return result.ToList();

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

        public List<ProcessMaster> GetOrderProcessMasters(int ProductID)
        {
            var res = from PM in dbContext.ProcessMasters
                      join PT in dbContext.ProductTypes on PM.ProductID equals PT.ProductTypeID
                      where PT.ProductTypeID == ProductID
                      select new ProcessMaster
                      {
                          id = PM.id,
                          ProcessName = PM.ProcessName,
                          ProductID = PM.ProductID,
                          productType = PT
                      };
            return res.ToList();
        }
    }
}
