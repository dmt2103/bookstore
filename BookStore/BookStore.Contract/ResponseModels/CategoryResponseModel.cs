using System;

namespace BookStore.Contract.ResponseModels
{
    public class CategoryResponseModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}