

using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;


public class ProductRepository : IProductRepository
{
    ApplicationDbContext _productContext;
    public ProductRepository(ApplicationDbContext context)
    {
        _productContext = context;        
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _productContext.Add(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetByIdAsync(int? id)
    {
        return await _productContext.products!.FindAsync(id) ?? new Product("Product Not Found","aaaa",0,0,"");
    }

    public async Task<Product> GetProductCategoryAsync(int? id)
    {
        return await _productContext.products!.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id)
             ?? new Product("Product Not Found","aaaa",0,0,"");
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _productContext.products!.ToListAsync() ?? new List<Product>();
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        _productContext.Remove(product);
        await _productContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _productContext.Update(product);
        await _productContext.SaveChangesAsync();
        return product;
    }
}