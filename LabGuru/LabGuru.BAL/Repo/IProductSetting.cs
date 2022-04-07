using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IProductSetting
    {
        int AddDeliveryDays(ProductSetting productSetting);
        int UpdateDeliveryDays(ProductSetting productSetting);

        ProductSetting GetProductDeliveryDays(int ProductID);

    }
}
