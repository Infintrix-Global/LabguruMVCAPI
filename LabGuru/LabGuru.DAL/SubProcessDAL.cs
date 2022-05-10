using LabGuru.BAL;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.DAL
{
    public class SubProcessDAL
    {
        private readonly LabGuruDbContext dbContext;

        public SubProcessDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int AddSubProcess(SubProcessMaster spm)
        {
            dbContext.SubProcessMasters.Add(spm);
            return dbContext.SaveChanges();
        }

        public int AddSubProcessEmployee(SubProcessEmployee sbe)
        {
            dbContext.SubProcessEmployees.Add(sbe);
            return dbContext.SaveChanges();
        }

        public List<SubProcessMaster> GetAllSubProcess(int LabID)
        {
            List<SubProcessMaster> sbm = new List<SubProcessMaster>();
            return sbm;

            //var Result = from sbm in dbContext.SubProcessMasters
            //             join pm in dbContext.ProcessMasters on sbm.ProcessID equals pm.id
            //             join l in dbContext.Laboratories on ppe.LabID equals l.id
            //             join le in dbContext.LabEmployees on ppe.LabEmployeeID equals le.LabEmployeeID
            //             join pm in dbContext.ProcessMasters on ppe.ProcessID equals pm.id
            //             select new ProductProcessEmployee
            //             {
            //                 ProductProcessEmployeeID = ppe.ProductProcessEmployeeID,
            //                 ProcessID = ppe.ProcessID,
            //                 ProductTypeID = ppe.ProductTypeID,
            //                 LabID = ppe.LabID,
            //                 LabEmployeeID = ppe.LabEmployeeID,
            //                 ProductTypes = pt,
            //                 ProcessMasters = pm,
            //                 Laboratories = l,
            //                 LabEmployees = le
            //             };

            //return Result.OrderBy(s => s.ProcessMasters.ProcessName).ToList();


        }

        public List<SubProcessEmployee> GetSubProcessEmployee(int LabID)
        {
            List<SubProcessEmployee> sbe = new List<SubProcessEmployee>();
            return sbe;
        }
    }
}
