using CarvedRock.Admin.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarvedRock.Admin.Models;

public class ProductModel
{
  public int Id { get; set; }

  [Required(), DisplayName("Product Name")]
  public string Name { get; set; } = string.Empty;

  [Required()]
  public string Description { get; set; } = string.Empty;

  [DataType(DataType.Currency), 
    Range(0.01, 1000.00, ErrorMessage = "Value for {0} must be between {1:C} and {2:C}.")]
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