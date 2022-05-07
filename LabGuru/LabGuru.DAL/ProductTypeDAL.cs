using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
    public class ProductTypeDAL : IProductTypeManage
    {
        private readonly LabGuruDbContext dbContext;

        public ProductTypeDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<ProductType> GetProductTypes()
        {
            var result = dbContext.ProductTypes.ToList();
            return result;
        }

        public ProductType GetProductType(int ProductTypeID)
        {
            var result = dbContext.ProductTypes.Where(w=>w.ProductTypeID == ProductTypeID).FirstOrDefault();
            return result;
        }

        public int CreateProductType(ProductType productType)
        {
            dbContext.ProductTypes.Add(productType);
            return dbContext.SaveChanges();
        }
    }
}
