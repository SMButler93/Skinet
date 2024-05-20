using Core.Entities;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class SkinetDbContextSeed
    {
        public static async Task SeedAsync(SkinetDbContext dbContext)
        {
            if (!dbContext.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                dbContext.ProductBrands.AddRange(brands);
            }

            if (!dbContext.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                dbContext.ProductTypes.AddRange(types);
            }

            if (!dbContext.ProductBrands.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                dbContext.Products.AddRange(products);
            }

            if (dbContext.ChangeTracker.HasChanges())
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
