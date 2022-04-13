using BasicAuthentication_.NET_6._0.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicAuthentication_.NET_6._0.Services
{
    public interface IProductService
    {
        public Task<List<Product>> Get();
    }
}
