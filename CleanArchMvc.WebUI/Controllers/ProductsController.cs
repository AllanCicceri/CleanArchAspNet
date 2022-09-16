using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        var products = await _productService.GetProductsAsync();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();                
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDTO productDTO)
    {
        if(ModelState.IsValid)
        {
            await _productService.CreateAsync(productDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(productDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var categoryDTO = await _productService.GetByIdAsync(id);

        if (categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDTO productDTO)
    {
        if (ModelState.IsValid)
        {
            await _productService.UpdateAsync(productDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(productDTO);
    }

[HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var categoryDTO = await _productService.GetByIdAsync(id);

        if (categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        await _productService.RemoveAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var categoryDTO = await _productService.GetByIdAsync(id);

        if (categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

}