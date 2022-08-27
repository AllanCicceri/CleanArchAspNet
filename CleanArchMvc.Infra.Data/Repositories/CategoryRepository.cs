
using CleanArch.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    ApplicationDbContext _categoryContext;
    public CategoryRepository(ApplicationDbContext context)
    {
        _categoryContext = context;
    }

    public async Task<Category> Create(Category category)
    {
        _categoryContext.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> GetById(int? id)
    {
        return await _categoryContext.categories!.FindAsync(id) ?? new Category("Category Not found");
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _categoryContext.categories!.ToListAsync() ?? new List<Category>();
    }

    public async Task<Category> Remove(Category category)
    {
        _categoryContext.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _categoryContext.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}