using LabGuru.BAL;
using LabGuru.BAL.Repo;
using LabGuru.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabGuru.DAL
{
    public class ProductSettingDAL : IProductSetting
    {
        private readonly LabGuruDbContext dbContext;

        public ProductSettingDAL(LabGuruDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int AddDeliveryDays(ProductSetting productSetting)
        {
            dbContext.Add(productSetting);
            return dbContext.SaveChanges();
        }

        public ProductSetting GetProductDeliveryDays(int ProductID)
        {
          return  dbContext.ProductSettings.Where(w => w.ProductID == ProductID).FirstOrDefault();
        }

        public int UpdateDeliveryDays(ProductSetting productSetting)
        {
            var result = dbContext.ProductSettings.Where(w => w.ProductID == productSetting.ProductID).FirstOrDefault();
            result.DeliveryDays = productSetting.DeliveryDays;
            return dbContext.SaveChanges();
        }
    }
}
