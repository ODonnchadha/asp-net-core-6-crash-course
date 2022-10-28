using Microsoft.AspNetCore.Mvc;
using CarvedRock.Admin.Contexts;
using CarvedRock.Admin.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Admin.Controllers;

public class CategoriesController : Controller
{
  private readonly ProductContext context;
  public CategoriesController(ProductContext context) => this.context = context;

  [HttpGet()]
  public async Task<IActionResult> Index()
  {
    var categories = await context.Categories.ToListAsync();
    return View(categories);
  }


  [HttpGet()]
  public async Task<IActionResult> Details(int? id)
  {
    if (id == null)
    {
      return View("NotFound");
    }

    var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
    if (category == null)
    {
      return View("NotFound");
    }

    return View(category);
  }

  [HttpGet()]
  public IActionResult Create() => View();
  
  [HttpPost(), ValidateAntiForgeryToken()]
  public async Task<IActionResult> Create([Bind("Id,Name")] Category model)
  {
    if (ModelState.IsValid)
    {
      context.Add(model);
      await context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    return View(model);
  }

  [HttpGet()]
  public async Task<IActionResult> Edit(int? id)
  {
    if (id == null)
    {
      return View("NotFound");
    }

    var category = await context.Categories.FindAsync(id.Value);

    if (category == null) 
    {
      return View("NotFound");
    }

    return View(category);
  }

  [HttpPost(), ValidateAntiForgeryToken()]
  public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category model)
  {
    if (id != model.Id) return View("NotFound");
    
    if (ModelState.IsValid)
    {
      try
      {
        context.Update(model);
        await context.SaveChangesAsync();
      }
      catch
      {
        throw;
      }
      return RedirectToAction(nameof(Index));
    }
    return View(model);
  }

  [HttpGet()]
  public async Task<IActionResult> Delete(int? id)
  {
    if (id == null) return View("NotFound");
    var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id.Value);
    if (category == null) return View("NotFound");
    return View(category);
  }

  [HttpPost(), ActionName("Delete"), ValidateAntiForgeryToken()]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    var category = await context.Categories.FindAsync(id);
    if (category == null) return View("NotFound");

    // NOTE: SQLite Error 19: 'FOREIGN KEY constraint failed'.
    context.Categories.Remove(category);
    await context.SaveChangesAsync();
    
    return RedirectToAction(nameof(Index));
  }
}