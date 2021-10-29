using System;

namespace BookStore.Contract.RequestModels
{
    public class CategoryRequestModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}