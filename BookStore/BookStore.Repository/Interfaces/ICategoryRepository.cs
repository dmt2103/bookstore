using BookStore.Domain.Models;
using System;
using System.Collections.Generic;

namespace BookStore.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category CreateCategory(Category category);
        Category GetCategory(Guid? categoryId);
        Category UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}