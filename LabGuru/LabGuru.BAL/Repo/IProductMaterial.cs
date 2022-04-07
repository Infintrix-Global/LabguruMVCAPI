using System;
using System.Collections.Generic;
using System.Text;

namespace LabGuru.BAL.Repo
{
    public interface IProductMaterial
    {
        List<ProductMaterial> GetProductMaterials();
        ProductMaterial GetProductMaterial(int ProductMaterialID);
    }
}
