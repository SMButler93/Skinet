using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetAllProductsAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync();
    }
}
