using CarvedRock.Admin.Interfaces.Managers;
using CarvedRock.Admin.Interfaces.Repositories;
using CarvedRock.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

  public async Task<ProductModel> InitializeProductModel() => 
    new ProductModel { AvailableCategories = await GetAvailableCategoriesAsync() };
  
  private async Task<List<SelectListItem>> GetAvailableCategoriesAsync()
  {
    var categories = await repository.GetAllCategoriesAsync();
    var list = new List<SelectListItem> { new SelectListItem("None", "") };
    var range = categories.Select(c => new SelectListItem(c.Name, c.Id.ToString()));
    list.AddRange(range);

    return list;
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