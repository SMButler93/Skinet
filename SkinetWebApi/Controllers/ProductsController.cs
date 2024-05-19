using Core.DomainModels;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SkinetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SkinetDbContext _dbContext;

        public ProductsController(SkinetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _dbContext.Products.ToListAsync();

            return Ok(products);
        }
    }
}