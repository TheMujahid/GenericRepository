using Application.BusinessDomain.IService;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WEP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var result = await _service.CreateProduct(product);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _service.GetAllProducts();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProductById/{Id}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var data = await _service.GetProductById(Id);
            return Ok(data);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var data = await _service.UpdateProduct(product);
            return Ok(data);
        }
    }
}
