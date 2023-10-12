using System;
using Catalog.Domain.Entities;

namespace Catalog.Application.Interfaces
{
	public interface ICategoryRepository
	{
        void Add(Category category);
        Category Get(int id);
        IEnumerable<Category> List();
        void Update(Category category);
        void Delete(int id);
    }
}

