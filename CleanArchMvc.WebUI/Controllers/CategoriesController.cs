using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class CategoriesController:Controller
{
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categService)
    {
        _categoryService = categService;        
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetCategoriesAsync();
        return View(categories);        
    }
}