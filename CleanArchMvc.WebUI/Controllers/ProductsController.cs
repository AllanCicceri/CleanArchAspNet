using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService prodService)
    {
        _productService = prodService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _productService.getProducts();
        return View(products);
    }
}