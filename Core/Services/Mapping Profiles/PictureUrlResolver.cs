global using Domain.Entities;
global using Microsoft.Extensions.Configuration;

namespace Services.Mapping_Profiles
{
    internal class PictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductResultDTO, string>
    {
        public string Resolve(Product source, ProductResultDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrWhiteSpace(source.PictureUrl)) return string.Empty;

            //return $"{source.PictureUrl}"; this is not an efficient way since Base Url is different from host to another
            return $"{configuration["BaseUrl"]}{source.PictureUrl}";
        }
    }
}
