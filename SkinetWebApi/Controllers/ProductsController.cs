using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace SkinetWebApi.Controllers
{
    public class ProductsController : BaseController
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
            var spec = new ProductsWithTypeAndBrandSpecification();

            return Ok(await _productsRepo.ListAllBySpecAsync(spec));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
        {
            var spec = new ProductsWithTypeAndBrandSpecification(id);

            return Ok(await _productsRepo.GetEntityBySpecAsync(spec));
        }

        [HttpGet]
        [Route("Brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetAllBrands()
        {
            return Ok(await _productBrandsRepo.GetAllAsync());
        }

        [HttpGet]
        [Route("Types")]
        public async Task<ActionResult<List<ProductType>>> GetAllTypes()
        {
            var spec = new ProductTypeSpecification();

            return Ok(await _productTypeRepo.ListAllBySpecAsync(spec));
        }
    }
}