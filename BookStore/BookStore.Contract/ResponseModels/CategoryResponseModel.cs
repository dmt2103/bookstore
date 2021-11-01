using System;
using System.Collections.Generic;

namespace BookStore.Contract.ResponseModels
{
    public class CategoryResponseModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<BookResponseModel> Books { get; set; }
    }
}