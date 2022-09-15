using CleanArch.Domain.Entities;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArchMvc.WebUI.Controllers;

public class CategoriesController : Controller
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

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO categoryDTO)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.CreateAsync(categoryDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(categoryDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var categoryDTO = await _categoryService.GetByIdAsync(id);

        if (categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.UpdateAsync(categoryDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(categoryDTO);
    }



    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var categoryDTO = await _categoryService.GetByIdAsync(id);

        if (categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        await _categoryService.RemoveAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var categoryDTO = await _categoryService.GetByIdAsync(id);

        if (categoryDTO == null) return NotFound();

        return View(categoryDTO);
    }
}