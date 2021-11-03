using BookStore.Contract.RequestModels;
using BookStore.Domain.Models;
using BookStore.Repository.Interfaces;
using Moq;
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
    }
}