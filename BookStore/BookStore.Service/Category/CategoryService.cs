using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using BookStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;

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

        public List<CategoryResponseModel> GetAllCategories()
        {
            var res = _categoryRepository.GetAllCategories();
            var allCategories = _mapper.Map<List<Domain.Models.Category>, List<CategoryResponseModel>>(res);
            return allCategories;
        }

        public CategoryResponseModel CreateCategory(CategoryRequestModel request)
        {
            var req = _mapper.Map<CategoryRequestModel, Domain.Models.Category>(request);
            var res = _categoryRepository.CreateCategory(req);
            var category = _mapper.Map<Domain.Models.Category, CategoryResponseModel>(res);
            return category;
        }

        public CategoryResponseModel GetCategory(Guid? request)
        {
            var res = _categoryRepository.GetCategory(request);
            var category = _mapper.Map<Domain.Models.Category, CategoryResponseModel>(res);
            return category;
        }

        public CategoryResponseModel UpdateCategory(CategoryRequestModel request)
        {
            var req = _mapper.Map<CategoryRequestModel, Domain.Models.Category>(request);
            var res = _categoryRepository.UpdateCategory(req);
            var category = _mapper.Map<Domain.Models.Category, CategoryResponseModel>(res);
            return category;
        }

        public void DeleteCategory(Guid request)
        {
            var category = _categoryRepository.GetCategory(request);
            _categoryRepository.DeleteCategory(category);
        }
    }
}