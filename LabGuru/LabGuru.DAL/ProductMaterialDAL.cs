using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
    public class ProductMaterialDAL : IProductMaterial
    {
        private readonly LabGuruDbContext dbContext;

        public ProductMaterialDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ProductMaterial GetProductMaterial(int ProductMaterialID)
        {
            return dbContext.ProductMaterials.Where(w => w.ProductMaterialID == ProductMaterialID).FirstOrDefault();
        }

        public List<ProductMaterial> GetProductMaterials()
        {
            try
            {
                return dbContext.ProductMaterials.ToList();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }
}
