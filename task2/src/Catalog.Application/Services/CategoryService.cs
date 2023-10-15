using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;

namespace Catalog.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task<int> Add(Category category)
    {
        return await categoryRepository.Add(category);
    }

    public async Task Delete(int id)
    {
        await categoryRepository.Delete(id);
    }

    public async Task<Category> Get(int id)
    {
        return await categoryRepository.Get(id);
    }

    public async Task<IEnumerable<Category>> List()
    {
        return await categoryRepository.List();
    }

    public async Task Update(Category category)
    {
        await categoryRepository.Update(category);
    }
}

