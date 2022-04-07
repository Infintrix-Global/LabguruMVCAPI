using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IProductTypeManage
    {
        List<ProductType> GetProductTypes();
        ProductType GetProductType(int ProductTypeID);
    }
}
