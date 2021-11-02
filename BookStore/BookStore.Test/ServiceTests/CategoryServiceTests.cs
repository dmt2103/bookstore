using AutoMapper;
using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using BookStore.Domain.Models;
using BookStore.Repository.Interfaces;
using BookStore.Service.Category;
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
        public void TestGetAllCategories()
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

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repository => repository.GetAllCategories(It.IsAny<string>()))
                .Returns(allCategories);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(mapper => mapper.Map<List<Category>, List<CategoryResponseModel>>(allCategories))
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
            var results = categoryService.GetAllCategories("x");

            // Assert
            Assert.AreEqual(2, results.Count);

            mockCategoryRepository.Verify(repository => repository.GetAllCategories("x"), Times.Once);

            mockMapper.Verify(repository => repository.Map<List<Category>, List<CategoryResponseModel>>(allCategories), Times.Once);
        }

        [TestMethod]
        public void TestCreateCategory()
        {
            // Arrange
            var categoryRequestModel = new CategoryRequestModel();
            var category = new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<Book>()
            };

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repository => repository.CreateCategory(categoryRequestModel))
                .Returns(category);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(mapper => mapper.Map<Category, CategoryResponseModel>(category))
                .Returns(new CategoryResponseModel
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = "CategoryName",
                    Description = "Description",
                    Books = new List<BookResponseModel>()
                });

            var categoryService = new CategoryService(mockCategoryRepository.Object, mockMapper.Object);

            // Act
            var results = categoryService.CreateCategory(categoryRequestModel);

            // Assert
            mockCategoryRepository.Verify(repository => repository.CreateCategory(categoryRequestModel), Times.Once);

            mockMapper.Verify(repository => repository.Map<Category, CategoryResponseModel>(category), Times.Once);
        }
    }
}