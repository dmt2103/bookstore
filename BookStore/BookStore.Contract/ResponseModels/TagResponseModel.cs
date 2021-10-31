using System;
using System.Collections.Generic;

namespace BookStore.Contract.ResponseModels
{
    public class TagResponseModel
    {
        public Guid TagId { get; set; }
        public string TagName { get; set; }
        public IEnumerable<BookResponseModel> Books { get; set; }
    }
}