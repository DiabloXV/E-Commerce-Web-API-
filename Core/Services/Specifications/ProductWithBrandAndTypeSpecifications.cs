global using Shared;
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

        public ProductWithBrandAndTypeSpecifications(ProductSpecificationsParameters parameters) :
            base(product => (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId) &&
             (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId) &&
            (string.IsNullOrWhiteSpace(parameters.Search) || product.Name.ToLower().Contains(parameters.Search.ToLower().Trim())))
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
           
            ApplyPagination(parameters.PageIndex, parameters.PageSize);

            if (parameters.Sort is not null)
            {
                switch (parameters.Sort)
                {
                    case ProductSortingOptions.PriceDesc:
                        SetOrderByDescending(p => p.Price);
                        break;
                    case ProductSortingOptions.PriceAsc:
                        SetOrderyBy(p => p.Price);
                        break;
                    case ProductSortingOptions.NameDesc:
                        SetOrderByDescending(p => p.Name);
                        break;
                    default:
                        SetOrderyBy(p => p.Name);
                        break;
                }
            }
        }
    }
}
