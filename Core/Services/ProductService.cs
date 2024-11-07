global using Services.Abstractions;
global using Shared;
global using AutoMapper;
global using Domain.Contracts;
using Domain.Entities;
using Services.Specifications;

namespace Services
{
    internal class ProductService (IUnitOfWork UnitOfWork, IMapper Mapper) : IProductService // We leave it internal because we don't want to expose the implementation to the outer layers
    {
        public async Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync()
        {
            //1. Retrieve all Brands => unit of work
            var brands = await UnitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            //2. Map to Brand Result => IMapper
            var BrandResult = Mapper.Map<IEnumerable<BrandResultDTO>>(brands);
            //3. Return
            return BrandResult;
        }

        public async Task<PaginatedResult<ProductResultDTO>> GetAllProductsAsync(ProductSpecificationsParameters parameters)
        {
            var products = await UnitOfWork.GetRepository <Product, int>().GetAllAsync(new ProductWithBrandAndTypeSpecifications(parameters));
            var productsResult = Mapper.Map <IEnumerable<ProductResultDTO>> (products);
            var count = productsResult.Count();
            var totalCount = await UnitOfWork.GetRepository<Product, int>().CountAsync(new ProductCountSpecifications(parameters));
            var result = new PaginatedResult<ProductResultDTO>(parameters.PageIndex, count, totalCount, productsResult);

            return result;
        }

        public async Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync()
        {
            var types = await UnitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var typesResult = Mapper.Map<IEnumerable<TypeResultDTO>>(types);
            return typesResult;
        }

        public async Task <ProductResultDTO?> GetProductsByIdAsync(int Id)
        {
            var product = await UnitOfWork.GetRepository <Product, int>().GetAsync(new ProductWithBrandAndTypeSpecifications(Id));
            var productResult = Mapper.Map<ProductResultDTO>(product);
            return productResult;
        }
    }
}
