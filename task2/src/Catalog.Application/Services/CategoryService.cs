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

    public void Add(Category category)
    {
        categoryRepository.Add(category);
    }

    public void Delete(int id)
    {
        categoryRepository.Delete(id);
    }

    public Category Get(int id)
    {
        return categoryRepository.Get(id);
    }

    public IEnumerable<Category> List()
    {
        return categoryRepository.List();
    }

    public void Update(Category category)
    {
        categoryRepository.Update(category);
    }
}

