using CarvedRock.Admin.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
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
  public int CategoryId { get; set; }

  [DisplayName("Category")]
  public string? CategoryName { get; set; } = null!;

  public List<SelectListItem> AvailableCategories { get; set; } = null!;
  public static ProductModel FromProduct(Product p)
  {
    return new ProductModel
    {
      Id = p.Id,
      Name = p.Name,
      Description = p.Description,
      Price = p.Price,
      IsActive = p.IsActive,
      CategoryId = p.CategoryId ?? 0,
      CategoryName = p.Category?.Name
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
      IsActive = IsActive,
      CategoryId = CategoryId
    };
  }
}