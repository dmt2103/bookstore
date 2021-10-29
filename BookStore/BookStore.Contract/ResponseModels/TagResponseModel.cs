using System;

namespace BookStore.Contract.ResponseModels
{
    public class TagResponseModel
    {
        public Guid TagId { get; set; }
        public string TagName { get; set; }
    }
}