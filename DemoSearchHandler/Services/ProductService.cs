using DemoSearchHandler.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DemoSearchHandler.Services
{
    internal class ProductService : IProductService
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await httpClient.GetAsync("https://fakestoreapi.com/products");
             var response = await products.Content.ReadFromJsonAsync<List<Product>>();
            return response;

        }
    }
}
