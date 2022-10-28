using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarvedRock.Admin.Models;

public class CategoryModel
{
    public int Id { get; set; }

    [Required(), DisplayName("Category Name")]
    public string Name { get; set; } = null!;
}