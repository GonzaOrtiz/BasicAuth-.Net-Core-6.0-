using BasicAuthentication_.NET_6._0.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasicAuthentication_.NET_6._0.Services
{
    public class ProductService : IProductService
    {
        string path = @"C:\Users\GONZALO\source\repos\BasicAuthentication .NET 6.0\BasicAuthentication .NET 6.0\Products.json";


        public async Task<List<Product>> Get()
        {
            string content = await File.ReadAllTextAsync(path);
            var Products = JsonSerializer.Deserialize<List<Product>>(content);
            return Products;
        }
    }
}
