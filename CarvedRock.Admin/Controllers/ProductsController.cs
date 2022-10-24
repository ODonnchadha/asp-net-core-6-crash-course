using Microsoft.AspNetCore.Mvc;
using CarvedRock.Admin.Models;
using CarvedRock.Admin.Interfaces.Managers;

namespace CarvedRock.Admin.Controllers;

public class ProductsController : Controller
{
  private readonly ILogger<ProductsController> logger;
  private readonly IProductManager manager;
  public ProductsController(ILogger<ProductsController> logger, IProductManager manager) 
  {
    this.logger = logger;
    this.manager = manager;
  }

  [HttpGet()]
  public async Task<IActionResult> Index()
  {
    var products = await manager.GetAllProductsAsync();
    return View(products);
  }

  [HttpGet()]
  public async Task<IActionResult> Details(int id)
  {
    var product = await manager.GetProductByIdAsync(id);
    if (product == null)
    {
      logger.LogInformation($"Product Detail {id} was not found.");
      return View("NotFound");
    }

    return View(product);
  }

  [HttpGet()]
  public IActionResult Create() => View();
  
  [HttpPost(), ValidateAntiForgeryToken()]
  public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,IsActive")] ProductModel model)
  {
    if (ModelState.IsValid)
    {
      await manager.AddProductAsync(model);
      return RedirectToAction(nameof(Index));
    }
    return View(model);
  }

  [HttpGet()]
  public async Task<IActionResult> Edit(int? id)
  {
    if (id == null)
    {
      logger.LogInformation($"Product edit id was not provided.");
      return View("NotFound");
    }

    var product = await manager.GetProductByIdAsync(id.Value);

    if (product == null) 
    {
      logger.LogInformation($"Product {id} for edit was not found.");
      return View("NotFound");
    }

    return View(product);
  }

  [HttpPost(), ValidateAntiForgeryToken()]
  public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,IsActive")] ProductModel model)
  {
    if (id != model.Id) return View("NotFound");
    if (ModelState.IsValid)
    {
      await manager.UpdateProductAsync(model);
      return RedirectToAction(nameof(Index));
    }
    return View(model);
  }

  [HttpGet()]
  public async Task<IActionResult> Delete(int? id)
  {
    if (id == null) return View("NotFound");
    var product = await manager.GetProductByIdAsync(id.Value);
    if (product == null) return View("NotFound");
    return View(product);
  }

  [HttpPost(), ActionName("Delete"), ValidateAntiForgeryToken()]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    await manager.RemoveProductAsync(id);
    return RedirectToAction(nameof(Index));
  }
}