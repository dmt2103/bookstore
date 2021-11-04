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
        public void CategoryService_GetAllCategories_NoCategories()
        {
            // Arrange
            var allCategories = new List<Category>();

            var mockCategoryRepository = new MockCategoryRepository().MockGetAllCategories(allCategories);
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<Category>, List<CategoryResponseModel>>(allCategories))
                .Returns(new List<CategoryResponseModel>());

            var categoryService = new CategoryService(mockCategoryRepository.Object, mockMapper.Object);

            // Act
            var results = categoryService.GetAllCategories(new string(""));

            // Assert
            Assert.AreEqual(0, results.Count);

            mockCategoryRepository.VerifyGetAllCategories(Times.Once());

            mockMapper.Verify(x => x.Map<List<Category>, List<CategoryResponseModel>>(allCategories), Times.Once);
        }

        [TestMethod]
        public void CategoryService_GetAllCategories_CategoriesExist()
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
                    },
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
            Assert.AreEqual(2, results.Count);

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

            var categoryResponse = new CategoryResponseModel
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<BookResponseModel>()
            };

            var mockCategoryRepository = new MockCategoryRepository().MockCreateCategory(category);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Category, CategoryResponseModel>(category))
                .Returns(categoryResponse);

            var categoryService = new CategoryService(mockCategoryRepository.Object, mockMapper.Object);

            // Act
            var result = categoryService.CreateCategory(new CategoryRequestModel());

            // Assert
            Assert.AreEqual(categoryResponse, result);

            mockCategoryRepository.VerifyCreateCategory(Times.Once());

            mockMapper.Verify(x => x.Map<Category, CategoryResponseModel>(category), Times.Once);
        }

        [TestMethod]
        public void CategoryService_GetCategory_NoCategories()
        {
            // Arrange
            var category = new Category();
            var categoryResponse = new CategoryResponseModel();

            var mockCategoryRepository = new MockCategoryRepository().MockGetCategory(category);
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Category, CategoryResponseModel>(category))
                .Returns(categoryResponse);

            var categoryService = new CategoryService(mockCategoryRepository.Object, mockMapper.Object);

            // Act
            var result = categoryService.GetCategory(Guid.NewGuid());

            // Assert
            Assert.AreEqual(categoryResponse, result);

            mockCategoryRepository.VerifyGetCategory(Times.Once());

            mockMapper.Verify(x => x.Map<Category, CategoryResponseModel>(category), Times.Once);
        }

        [TestMethod]
        public void CategoryService_GetCategory_CategoriesExist()
        {
            // Arrange
            var category = new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<Book>()
            };

            var categoryResponse = new CategoryResponseModel
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<BookResponseModel>()
            };

            var mockCategoryRepository = new MockCategoryRepository().MockGetCategory(category);
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Category, CategoryResponseModel>(category))
                .Returns(categoryResponse);

            var categoryService = new CategoryService(mockCategoryRepository.Object, mockMapper.Object);

            // Act
            var result = categoryService.GetCategory(Guid.NewGuid());

            // Assert
            Assert.AreEqual(categoryResponse, result);

            mockCategoryRepository.VerifyGetCategory(Times.Once());

            mockMapper.Verify(x => x.Map<Category, CategoryResponseModel>(category), Times.Once);
        }

        [TestMethod]
        public void CategoryService_UpdateCategory_Valid()
        {
            // Arrange
            var category = new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<Book>()
            };

            var categoryResponse = new CategoryResponseModel
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<BookResponseModel>()
            };

            var mockCategoryRepository = new MockCategoryRepository().MockUpdateCategory(category);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<Category, CategoryResponseModel>(category))
                .Returns(categoryResponse);

            var categoryService = new CategoryService(mockCategoryRepository.Object, mockMapper.Object);

            // Act
            var result = categoryService.UpdateCategory(new CategoryRequestModel());

            // Assert
            Assert.AreEqual(categoryResponse, result);

            mockCategoryRepository.VerifyUpdateCategory(Times.Once());

            mockMapper.Verify(x => x.Map<Category, CategoryResponseModel>(category), Times.Once);
        }

        [TestMethod]
        public void CategoryService_DeleteCategory_Valid()
        {
            // Arrange
            var mockCategoryRepository = new MockCategoryRepository().MockDeleteCategory();
            var categoryService = new CategoryService(mockCategoryRepository.Object, null);

            // Act
            categoryService.DeleteCategory(Guid.NewGuid());

            // Assert
            mockCategoryRepository.VerifyDeleteCategory(Times.Once());
        }
    }
}