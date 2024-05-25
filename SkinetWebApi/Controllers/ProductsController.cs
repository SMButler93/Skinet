using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SkinetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productBrandsRepo, IGenericRepository<ProductType> productTypeRepo)
        {
            _productsRepo = productsRepo;
            _productBrandsRepo = productBrandsRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(await _productsRepo.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
        {
            return await _productsRepo.GetByIdAsync(id);
        }

        [HttpGet]
        [Route("Brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetAllBrands()
        {
            return Ok(await _productBrandsRepo.GetAllAsync());
        }

        [Route("Types")]
        [HttpGet]
        public async Task<ActionResult<List<ProductType>>> GetAllTypes()
        {
            return Ok(await _productTypeRepo.GetAllAsync());
        }
    }
}