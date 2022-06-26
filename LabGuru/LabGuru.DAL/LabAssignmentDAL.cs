using LabGuru.BAL;
using LabGuru.BAL.Component;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace LabGuru.DAL
{
    public class LabAssignmentDAL : ILabAssignment
    {
        private readonly LabGuruDbContext dbContext;

        public LabAssignmentDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int AssignmentToLab(LabAssignment labAssignment)
        {
            dbContext.LabAssignments.Add(labAssignment);
            return dbContext.SaveChanges();
        }

        //Not in use can come handy in future
        //public List<ProcessEmployeeDetail> GetProccessEmployeeDetails(int LabID)
        //{

        //    var employeeProcess = from ppe in dbContext.ProductProcessEmployees
        //                         join lb in dbContext.LabEmployees on ppe.LabID equals lb.LabID
        //                         where ppe.LabID == LabID
        //                         select new ProcessEmployeeDetail
        //                         {
        //                             LabEmployeeID = lb.LabEmployeeID,
        //                             EmployeeName = lb.EmployeeName,
        //                             ProcessAssignedCount = GetProceesCountForEmployee(lb.LabEmployeeID),
                                     
        //                         };

        //    return employeeProcess.ToList();
        //}

        //Not in use can come handy in future
        //public int GetProceesCountForEmployee(int LabEmployeeID)
        //{
        //    return dbContext.OrderDetailsByEmployeeProcess.Where(c => c.EmployeeID == LabEmployeeID && c.OrderProcessStatus == 1).Count();

        //}



    }
}
