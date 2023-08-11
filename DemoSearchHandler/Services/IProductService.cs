
using DemoSearchHandler.Models;

namespace DemoSearchHandler.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}
