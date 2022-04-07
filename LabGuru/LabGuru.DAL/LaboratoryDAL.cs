using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LabGuru.DAL
{
    public class LaboratoryDAL : ILaboratory
    {
        private readonly LabGuruDbContext dbContext;

        public LaboratoryDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Laboratory> GetLaboratories()
        {
            return dbContext.Laboratories.ToList();
        }

        public Laboratory GetLaboratory(int id)
        {
            return dbContext.Laboratories.Where(w => w.id == id).FirstOrDefault();
        }
    }
}
