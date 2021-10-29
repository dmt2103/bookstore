using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using System;
using System.Collections.Generic;

namespace BookStore.Service.Category
{
    public interface ICategoryService
    {
        List<CategoryResponseModel> GetAllCategories(string searchString);
        CategoryResponseModel CreateCategory(CategoryRequestModel request);
        CategoryResponseModel GetCategory(Guid? request);
        CategoryResponseModel UpdateCategory(CategoryRequestModel request);
        void DeleteCategory(Guid request);
    }
}