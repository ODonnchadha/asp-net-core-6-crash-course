using CarvedRock.Admin.Entities;

namespace CarvedRock.Admin.Interfaces.Repositories;

public interface ICarvedRockRepository
{
  Task<List<Product>> GetAllProductsAsync();
  Task<Product?> GetProductByIdAsync(int id);
  Task<Product> AddProductAsync(Product p);
  Task UpdateProductAsync(Product p);
  Task RemoveProductAsync(int id);
}