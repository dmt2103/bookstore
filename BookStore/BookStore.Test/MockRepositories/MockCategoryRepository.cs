using BookStore.Contract.RequestModels;
using BookStore.Domain.Models;
using BookStore.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace BookStore.Test.MockRepositories
{
    public class MockCategoryRepository : Mock<ICategoryRepository>
    {
        public MockCategoryRepository MockGetAllCategories(List<Category> allCategories)
        {
            Setup(x => x.GetAllCategories(It.IsAny<string>()))
                .Returns(allCategories);

            return this;
        }

        public MockCategoryRepository VerifyGetAllCategories(Times times)
        {
            Verify(x => x.GetAllCategories(It.IsAny<string>()), times);

            return this;
        }

        public MockCategoryRepository MockCreateCategory(Category category)
        {
            Setup(x => x.CreateCategory(It.IsAny<CategoryRequestModel>()))
                .Returns(category);

            return this;
        }

        public MockCategoryRepository VerifyCreateCategory(Times times)
        {
            Verify(x => x.CreateCategory(It.IsAny<CategoryRequestModel>()), times);

            return this;
        }

        public MockCategoryRepository MockGetCategory(Category category)
        {
            Setup(x => x.GetCategory(It.IsAny<Guid?>()))
                .Returns(category);

            return this;
        }

        public MockCategoryRepository VerifyGetCategory(Times times)
        {
            Verify(x => x.GetCategory(It.IsAny<Guid?>()), times);

            return this;
        }

        public MockCategoryRepository MockUpdateCategory(Category category)
        {
            Setup(x => x.UpdateCategory(It.IsAny<CategoryRequestModel>()))
                .Returns(category);

            return this;
        }

        public MockCategoryRepository VerifyUpdateCategory(Times times)
        {
            Verify(x => x.UpdateCategory(It.IsAny<CategoryRequestModel>()), times);

            return this;
        }

        public MockCategoryRepository MockDeleteCategory()
        {
            Setup(x => x.DeleteCategory(It.IsAny<Guid>()));

            return this;
        }

        public MockCategoryRepository VerifyDeleteCategory(Times times)
        {
            Verify(x => x.DeleteCategory(It.IsAny<Guid>()), times);

            return this;
        }
    }
}