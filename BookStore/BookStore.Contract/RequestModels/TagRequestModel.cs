using System;
using System.Collections.Generic;

namespace BookStore.Contract.RequestModels
{
    public class TagRequestModel
    {
        public Guid TagId { get; set; }
        public string TagName { get; set; }
        public IEnumerable<BookTagRequestModel> BookTags { get; set; }
    }
}