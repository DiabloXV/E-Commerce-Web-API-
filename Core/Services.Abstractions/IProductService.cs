global using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {
        //Get All Products
        public Task <IEnumerable<ProductResultDTO>> GetAllProductsAsync(ProductSpecificationsParameters parameters);
        //Get All Brands
        public Task <IEnumerable<BrandResultDTO>> GetAllBrandsAsync();
        //Get All Types
        public Task <IEnumerable<TypeResultDTO>>  GetAllTypesAsync();   
        //Get Product By ID
        public Task <ProductResultDTO?> GetProductsByIdAsync(int Id);
    }
}
