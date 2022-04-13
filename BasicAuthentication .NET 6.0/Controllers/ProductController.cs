using BasicAuthentication_.NET_6._0.Models;
using BasicAuthentication_.NET_6._0.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasicAuthentication_.NET_6._0.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _repositoryUser;
        public ProductController(IProductService repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get() =>  await _repositoryUser.Get();

    }
}
