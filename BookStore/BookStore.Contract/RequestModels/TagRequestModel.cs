using System;

namespace BookStore.Contract.RequestModels
{
    public class TagRequestModel
    {
        public Guid TagId { get; set; }
        public string TagName { get; set; }
    }
}