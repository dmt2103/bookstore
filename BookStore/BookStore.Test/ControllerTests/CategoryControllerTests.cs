using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using BookStore.Controllers;
using BookStore.Test.MockServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using AssertNUnit = NUnit.Framework.Assert;

namespace BookStore.Test.ControllerTests
{
    [TestClass]
    public class CategoryControllerTests
    {
        [TestMethod]
        public void CategoryController_Index_NoCategories()
        {
            // Arrange
            var mockCategoryService = new MockCategoryService().MockGetAllCategories(new List<CategoryResponseModel>());

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Index(new string(""));

            // Assert
            AssertNUnit.IsAssignableFrom<ViewResult>(result);

            mockCategoryService.VerifyGetAllCategories(Times.Once());
        }

        [TestMethod]
        public void CategoryController_Index_CategoriesExist()
        {
            // Arrange
            var categoryResponses = new List<CategoryResponseModel>
            {
                new CategoryResponseModel
                {
                    CategoryId = Guid.NewGuid(),
                    CategoryName = "CategoryName",
                    Description = "Description",
                    Books = new List<BookResponseModel>()
                }
            };

            var mockCategoryService = new MockCategoryService().MockGetAllCategories(categoryResponses);

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Index(new string(""));

            // Assert
            AssertNUnit.IsAssignableFrom<ViewResult>(result);

            mockCategoryService.VerifyGetAllCategories(Times.Once());
        }

        [TestMethod]
        public void CategoryController_Create_Post_ModelStateInvalid()
        {
            // Arrange
            var mockCategoryService = new MockCategoryService().MockCreateCategory(new CategoryResponseModel());

            var categoryController = new CategoryController(mockCategoryService.Object);
            categoryController.ModelState.AddModelError("Test", "Test");

            // Act
            var result = categoryController.Create(new CategoryRequestModel());

            // Assert
            AssertNUnit.IsAssignableFrom<ViewResult>(result);

            mockCategoryService.VerifyCreateCategory(Times.Never());
        }

        [TestMethod]
        public void CategoryController_Create_Post_Valid()
        {
            // Arrange
            var categoryResponse = new CategoryResponseModel
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<BookResponseModel>()
            };

            var mockCategoryService = new MockCategoryService().MockCreateCategory(categoryResponse);

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Create(new CategoryRequestModel());

            // Assert
            AssertNUnit.IsAssignableFrom<RedirectToActionResult>(result);

            var redirectToAction = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectToAction.ActionName);

            mockCategoryService.VerifyCreateCategory(Times.Once());
        }

        [TestMethod]
        public void CategoryController_Details_IdNull()
        {
            // Arrange
            var mockCategoryService = new MockCategoryService().MockGetCategory(new CategoryResponseModel());

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Details(null);

            // Assert
            AssertNUnit.IsAssignableFrom<NotFoundResult>(result);

            mockCategoryService.VerifyGetCategory(Times.Never());
        }

        [TestMethod]
        public void CategoryController_Details_NoCategories()
        {
            // Arrange
            var mockCategoryService = new MockCategoryService().MockGetCategory(null);

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Details(Guid.NewGuid());

            // Assert
            AssertNUnit.IsAssignableFrom<NotFoundResult>(result);

            mockCategoryService.VerifyGetCategory(Times.Once());
        }

        [TestMethod]
        public void CategoryController_Details_Valid()
        {
            // Arrange
            var categoryResponse = new CategoryResponseModel
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<BookResponseModel>()
            };

            var mockCategoryService = new MockCategoryService().MockGetCategory(categoryResponse);

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Details(Guid.NewGuid());

            // Assert
            AssertNUnit.IsAssignableFrom<ViewResult>(result);

            mockCategoryService.VerifyGetCategory(Times.Once());
        }

        [TestMethod]
        public void CategoryController_Update_Get_IdNull()
        {
            // Arrange
            var mockCategoryService = new MockCategoryService().MockGetCategory(new CategoryResponseModel());

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Update(null);

            // Assert
            AssertNUnit.IsAssignableFrom<NotFoundResult>(result);

            mockCategoryService.VerifyGetCategory(Times.Never());
        }

        [TestMethod]
        public void CategoryController_Update_Get_NoCategories()
        {
            // Arrange
            var mockCategoryService = new MockCategoryService().MockGetCategory(null);

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Update(Guid.NewGuid());

            // Assert
            AssertNUnit.IsAssignableFrom<NotFoundResult>(result);

            mockCategoryService.VerifyGetCategory(Times.Once());
        }

        [TestMethod]
        public void CategoryController_Update_Get_Valid()
        {
            // Arrange
            var categoryResponse = new CategoryResponseModel
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<BookResponseModel>()
            };

            var mockCategoryService = new MockCategoryService().MockGetCategory(categoryResponse);

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Update(Guid.NewGuid());

            // Assert
            AssertNUnit.IsAssignableFrom<ViewResult>(result);

            mockCategoryService.VerifyGetCategory(Times.Once());
        }

        [TestMethod]
        public void CategoryController_Update_Post_IdNotMatch()
        {
            // Arrange
            var mockCategoryService = new MockCategoryService().MockUpdateCategory(new CategoryResponseModel());

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Update(Guid.NewGuid(), new CategoryRequestModel());

            // Assert
            AssertNUnit.IsAssignableFrom<NotFoundResult>(result);

            mockCategoryService.VerifyUpdateCategory(Times.Never());
        }

        [TestMethod]
        public void CategoryController_Update_Post_ModelStateInvalid()
        {
            // Arrange
            var categoryRequest = new CategoryRequestModel();
            var mockCategoryService = new MockCategoryService().MockUpdateCategory(new CategoryResponseModel());

            var categoryController = new CategoryController(mockCategoryService.Object);
            categoryController.ModelState.AddModelError("Test", "Test");

            // Act
            var result = categoryController.Update(categoryRequest.CategoryId, categoryRequest);

            // Assert
            AssertNUnit.IsAssignableFrom<RedirectToActionResult>(result);

            var redirectToAction = (RedirectToActionResult)result;
            Assert.AreEqual("Update", redirectToAction.ActionName);

            mockCategoryService.VerifyUpdateCategory(Times.Never());
        }

        [TestMethod]
        public void CategoryController_Update_Post_Valid()
        {
            // Arrange
            var categoryRequest = new CategoryRequestModel();
            var mockCategoryService = new MockCategoryService().MockUpdateCategory(new CategoryResponseModel());

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Update(categoryRequest.CategoryId, categoryRequest);

            // Assert
            AssertNUnit.IsAssignableFrom<RedirectToActionResult>(result);

            var redirectToAction = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectToAction.ActionName);

            mockCategoryService.VerifyUpdateCategory(Times.Once());
        }

        [TestMethod]
        public void CategoryController_DeleteConfirm_IdNull()
        {
            // Arrange
            var mockCategoryService = new MockCategoryService().MockGetCategory(new CategoryResponseModel());

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.DeleteConfirm(null);

            // Assert
            AssertNUnit.IsAssignableFrom<NotFoundResult>(result);

            mockCategoryService.VerifyGetCategory(Times.Never());
        }

        [TestMethod]
        public void CategoryController_DeleteConfirm_NoCategories()
        {
            // Arrange
            var mockCategoryService = new MockCategoryService().MockGetCategory(null);

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.DeleteConfirm(Guid.NewGuid());

            // Assert
            AssertNUnit.IsAssignableFrom<NotFoundResult>(result);

            mockCategoryService.VerifyGetCategory(Times.Once());
        }

        [TestMethod]
        public void CategoryController_DeleteConfirm_Valid()
        {
            // Arrange
            var categoryResponse = new CategoryResponseModel
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "CategoryName",
                Description = "Description",
                Books = new List<BookResponseModel>()
            };

            var mockCategoryService = new MockCategoryService().MockGetCategory(categoryResponse);

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.DeleteConfirm(Guid.NewGuid());

            // Assert
            AssertNUnit.IsAssignableFrom<ViewResult>(result);

            mockCategoryService.VerifyGetCategory(Times.Once());
        }

        [TestMethod]
        public void CategoryController_Delete_Valid()
        {
            // Arrange
            var mockCategoryService = new MockCategoryService().MockDeleteCategory();

            var categoryController = new CategoryController(mockCategoryService.Object);

            // Act
            var result = categoryController.Delete(Guid.NewGuid());

            // Assert
            AssertNUnit.IsAssignableFrom<RedirectToActionResult>(result);

            var redirectToAction = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectToAction.ActionName);

            mockCategoryService.VerifyDeleteCategory(Times.Once());
        }
    }
}