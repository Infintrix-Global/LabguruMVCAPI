using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IProductShade
    {
        List<ProductShade> GetProductShades();
        ProductShade GetProductShade(int ProductShadeID);
    }
}
