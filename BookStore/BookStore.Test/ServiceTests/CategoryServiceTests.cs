using AutoMapper;
using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using BookStore.Domain.Models;
using BookStore.Service.Category;
using BookStore.Test.MockRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace BookStore.Test.ServiceTests
{
    [TestClass]
    public class CategoryServiceTests
    {
        [TestMethod]
        public void CategoryService_GetAllCategories_Valid()
        {
            // Arrange
            var allCategories = new List<Category>
            {
                new Category
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = "CategoryName",
                    Description = "Description",
                    Books = new List<Book>()
                }
            };

            var mockCategoryRepository = new MockCategoryRepository().MockGetAllCategories(allCategories);
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<Category>, List<CategoryResponseModel>>(allCategories))
                .Returns(new List<CategoryResponseModel>
                {
                    new CategoryResponseModel
                    {
                        CategoryId = Guid.NewGuid(),
                        CategoryName = "CategoryName",
                        Description = "Description",
                        Books = new List<BookResponseModel>()
                    }
                });

            var categoryService = new CategoryService(mockCategoryRepository.Object, mockMapper.Object);

            // Act
            var results = categoryService.GetAllCategories(new string(""));

            // Assert
            Assert.AreEqual(1, results.Count);

            mockCategoryRepository.VerifyGetAllCategories(Times.Once());

            mockMapper.Verify(x => x.Map<List<Category>, List<CategoryResponseModel>>(allCategories), Times.Once);
        }

        [TestMethod]
        public void CategoryService_CreateCategory_Valid()
        {
            // Arrange
            var category = new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<Book>()
            };

            var mockCategoryRepository = new MockCategoryRepository().MockCreateCategory(category);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Category, CategoryResponseModel>(category))
                .Returns(new CategoryResponseModel());

            var categoryService = new CategoryService(mockCategoryRepository.Object, mockMapper.Object);

            // Act
            var results = categoryService.CreateCategory(new CategoryRequestModel());

            // Assert
            mockCategoryRepository.VerifyCreateCategory(Times.Once());

            mockMapper.Verify(x => x.Map<Category, CategoryResponseModel>(category), Times.Once);
        }
    }
}