using Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping_Profiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductResultDTO>().ForMember(d => d.BrandName , options => options.MapFrom(s =>s.ProductBrand.Name))
                .ForMember(d => d.TypeName , options => options.MapFrom(s => s.ProductType.Name));
            CreateMap <ProductType, TypeResultDTO>();
            CreateMap <ProductBrand, BrandResultDTO>();
        }
    }
}
