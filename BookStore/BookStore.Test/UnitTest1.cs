using BookStore.Contract.RequestModels;
using BookStore.Service.Category;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // var ca = new Service.Category.CategoryService();

            var mock = new Moq.Mock<ICategoryService>();


            // Setup

            var input = new Contract.RequestModels.CategoryRequestModel();
            var response = new Contract.ResponseModels.CategoryResponseModel();

            mock.Setup(x => x.CreateCategory(input)).Returns(response);


            // Create instance 

            var controller = new Controllers.CategoryController(mock.Object);







            // Act


            var res = controller.Create(new CategoryRequestModel() { });

            var res = await res.ExecuteResultAsync();


            // Verify


            Assert.AreEqual( res, true)
        }
    }
}
