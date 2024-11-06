using System.Linq.Expressions;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications : Specifications<Product>
    {
        //Used to retrieve product By Id
        public ProductWithBrandAndTypeSpecifications(int id) : base(product => product.Id == id)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }
        //Used to get all products
        public ProductWithBrandAndTypeSpecifications() : base(null)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }
    }
}
