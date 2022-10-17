using CarvedRock.Admin.Entities;

namespace CarvedRock.Admin.Models;

public class ProductModel
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public bool IsActive { get; set; }
  public static ProductModel FromProduct(Product p)
  {
    return new ProductModel
    {
      Id = p.Id,
      Name = p.Name,
      Description = p.Description,
      Price = p.Price,
      IsActive = p.IsActive
    };
  }
  public Product ToProduct()
  {
    return new Product
    {
      Id = Id,
      Name = Name,
      Description = Description,
      Price = Price,
      IsActive = IsActive
    };
  }
}