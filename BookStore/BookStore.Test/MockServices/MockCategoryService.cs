using BookStore.Contract.RequestModels;
using BookStore.Contract.ResponseModels;
using BookStore.Service.Category;
using Moq;
using System;
using System.Collections.Generic;

namespace BookStore.Test.MockServices
{
    public class MockCategoryService : Mock<ICategoryService>
    {
        public MockCategoryService MockGetAllCategories(List<CategoryResponseModel> categoryResponses)
        {
            Setup(x => x.GetAllCategories(It.IsAny<string>()))
                .Returns(categoryResponses);

            return this;
        }

        public MockCategoryService VerifyGetAllCategories(Times times)
        {
            Verify(x => x.GetAllCategories(It.IsAny<string>()), times);

            return this;
        }

        public MockCategoryService MockCreateCategory(CategoryResponseModel categoryResponse)
        {
            Setup(x => x.CreateCategory(It.IsAny<CategoryRequestModel>()))
                .Returns(categoryResponse);

            return this;
        }

        public MockCategoryService VerifyCreateCategory(Times times)
        {
            Verify(x => x.CreateCategory(It.IsAny<CategoryRequestModel>()), times);

            return this;
        }

        public MockCategoryService MockGetCategory(CategoryResponseModel categoryResponse)
        {
            Setup(x => x.GetCategory(It.IsAny<Guid?>()))
                .Returns(categoryResponse);

            return this;
        }

        public MockCategoryService VerifyGetCategory(Times times)
        {
            Verify(x => x.GetCategory(It.IsAny<Guid?>()), times);

            return this;
        }

        public MockCategoryService MockUpdateCategory(CategoryResponseModel categoryResponse)
        {
            Setup(x => x.UpdateCategory(It.IsAny<CategoryRequestModel>()))
                .Returns(categoryResponse);

            return this;
        }

        public MockCategoryService VerifyUpdateCategory(Times times)
        {
            Verify(x => x.UpdateCategory(It.IsAny<CategoryRequestModel>()), times);

            return this;
        }

        public MockCategoryService MockDeleteCategory()
        {
            Setup(x => x.DeleteCategory(It.IsAny<Guid>()));

            return this;
        }

        public MockCategoryService VerifyDeleteCategory(Times times)
        {
            Verify(x => x.DeleteCategory(It.IsAny<Guid>()), times);

            return this;
        }
    }
}