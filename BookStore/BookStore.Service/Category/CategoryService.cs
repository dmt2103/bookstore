using AutoMapper;
using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using BookStore.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace BookStore.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public List<CategoryResponseModel> GetAllCategories(string searchString)
        {
            var allCategories = _categoryRepository.GetAllCategories(searchString);
            var response = _mapper.Map<List<Domain.Models.Category>, List<CategoryResponseModel>>(allCategories);

            return response;
        }

        public CategoryResponseModel CreateCategory(CategoryRequestModel request)
        {
            var category = _categoryRepository.CreateCategory(request);
            var response = _mapper.Map<Domain.Models.Category, CategoryResponseModel>(category);

            return response;
        }

        public CategoryResponseModel GetCategory(Guid? request)
        {
            var category = _categoryRepository.GetCategory(request);
            var response = _mapper.Map<Domain.Models.Category, CategoryResponseModel>(category);

            return response;
        }

        public CategoryResponseModel UpdateCategory(CategoryRequestModel request)
        {
            var category = _categoryRepository.UpdateCategory(request);
            var response = _mapper.Map<Domain.Models.Category, CategoryResponseModel>(category);

            return response;
        }

        public void DeleteCategory(Guid request)
        {
            _categoryRepository.DeleteCategory(request);
        }
    }
}