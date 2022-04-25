using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
