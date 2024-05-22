using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SkinetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(await _repository.GetAllProductsAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }

        [HttpGet]
        [Route("Brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetAllBrands()
        {
            return Ok(await _repository.GetAllProductBrandsAsync());
        }

        [Route("Types")]
        [HttpGet]
        public async Task<ActionResult<List<ProductType>>> GetAllTypes()
        {
            return Ok(await _repository.GetAllProductTypesAsync());
        }
    }
}