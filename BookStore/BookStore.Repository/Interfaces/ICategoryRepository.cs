using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using BookStore.Contract.RequestModels;

namespace BookStore.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories(string searchString);
        Category CreateCategory(CategoryRequestModel category);
        Category GetCategory(Guid? categoryId);
        Category UpdateCategory(CategoryRequestModel category);
        void DeleteCategory(Guid? categoryId);
    }
}