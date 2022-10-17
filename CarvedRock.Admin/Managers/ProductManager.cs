using CarvedRock.Admin.Interfaces.Managers;
using CarvedRock.Admin.Interfaces.Repositories;
using CarvedRock.Admin.Models;

namespace CarvedRock.Admin.Managers;

public class ProductManager : IProductManager
{
  private readonly ICarvedRockRepository repository;
  public ProductManager(ICarvedRockRepository repository) => this.repository = repository;

  public async Task AddProductAsync(ProductModel model)
  {
    var product = model.ToProduct();
    await repository.AddProductAsync(product);
  }

  public async Task<List<ProductModel>> GetAllProductsAsync()
  {
    var products = await repository.GetAllProductsAsync();
    return products.Select(ProductModel.FromProduct).ToList();
  }

  public async Task<ProductModel?> GetProductByIdAsync(int id)
  {
    var product = await repository.GetProductByIdAsync(id);
    return product == null ? null : ProductModel.FromProduct(product);
  }

  public async Task RemoveProductAsync(int id)
  {
    await repository.RemoveProductAsync(id);
  }

  public async Task UpdateProductAsync(ProductModel model)
  {
    var product = model.ToProduct();
    await repository.UpdateProductAsync(product);
  }
}