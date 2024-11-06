using System.IO.Pipes;

namespace Services.Abstractions
{
    public interface IServiceManager
    {
        public IProductService ProductService { get;}
    }
}
