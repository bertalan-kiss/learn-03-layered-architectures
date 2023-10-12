﻿using Catalog.Domain.Entities;

namespace Catalog.Application.Services
{
    public interface ICategoryService
    {
        void Add(Category category);
        Category Get(int id);
        IEnumerable<Category> List();
        void Update(Category category);
        void Delete(int id);
    }
}
