using CarvedRock.Admin.Models;

namespace CarvedRock.Admin.Interfaces.Managers;

public interface IProductManager
{
  Task<List<ProductModel>> GetAllProductsAsync();
  Task<ProductModel?> GetProductByIdAsync(int id);
  Task AddProductAsync(ProductModel model);
  Task UpdateProductAsync(ProductModel model);
  Task RemoveProductAsync(int id);
  Task<ProductModel> InitializeProductModel();
}