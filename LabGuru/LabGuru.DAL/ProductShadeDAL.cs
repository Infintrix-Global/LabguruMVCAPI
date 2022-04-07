using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
    public class ProductShadeDAL : IProductShade
    {
        private readonly LabGuruDbContext dbContext;

        public ProductShadeDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ProductShade GetProductShade(int ProductShadeID)
        {
            return dbContext.ProductShades.Where(w=>w.ProductShadeID == ProductShadeID).FirstOrDefault();
        }

        public List<ProductShade> GetProductShades()
        {
            return dbContext.ProductShades.ToList();
        }
    }
}
