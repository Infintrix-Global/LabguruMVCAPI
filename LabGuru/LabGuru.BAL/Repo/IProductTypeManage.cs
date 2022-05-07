using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IProductTypeManage
    {
        List<ProductType> GetProductTypes();
        int CreateProductType(ProductType productType);
        ProductType GetProductType(int ProductTypeID);
    }
}
