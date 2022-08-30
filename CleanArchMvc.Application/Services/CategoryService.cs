using AutoMapper;
using CleanArch.Domain.Entities;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services;

public class CategoryService : ICategoryService
{
    ICategoryRepository _categoryRepository;
    IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<CategoryDTO>> getCategories()
    {
        var categoriesEntity = await _categoryRepository.GetCategories();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }
    public async Task<CategoryDTO> GetById(int? id)
    {
        var categoryEntity = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }


    public async Task Add(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.Create(categoryEntity);
    }

    public async Task Update(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.Update(categoryEntity);    
    }

    public async Task Remove(int? id)
    {
        var categoriesEntity = _categoryRepository.GetById(id).Result;      
        await _categoryRepository.Remove(categoriesEntity);
    }

}