using CarvedRock.Admin.Contexts;
using CarvedRock.Admin.Entities;
using CarvedRock.Admin.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Admin.Repositories;

public class CarvedRockRepository : ICarvedRockRepository
{
  private readonly ProductContext context;
  public CarvedRockRepository(ProductContext context) => this.context = context;
  public async Task<Product> AddProductAsync(Product p)
  {
    context.Products.Add(p);
    await context.SaveChangesAsync();

    return p;
  }

  public async Task<List<Category>> GetAllCategoriesAsync() => await context.Categories.ToListAsync();

  public async Task<List<Product>> GetAllProductsAsync() => 
    await context.Products.Include(p => p.Category).ToListAsync();

  public async Task<Product?> GetProductByIdAsync(int id) => 
    await context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

  public async Task RemoveProductAsync(int id)
  {
    var p = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

    if (p != null)
    {
      context.Products.Remove(p);
      await context.SaveChangesAsync();
    }
  }

  public async Task UpdateProductAsync(Product p)
  {
    try
    {
      context.Update(p);
      await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (context.Products.Any(e => e.Id == p.Id))
      {
        // e.g.: p does exist and the attempted update should have been valid.
        throw;
      }
    }
  }
}