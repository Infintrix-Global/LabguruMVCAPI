using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
    public class ToothnoMastersDAL : IToothnoMasters
    {
        private readonly LabGuruDbContext dbContext;

        public ToothnoMastersDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<ToothNoMaster> GetToothNoMasters()
        {
            return dbContext.ToothNoMasters.ToList();
        }
    }
}
