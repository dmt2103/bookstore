using System;
using System.Collections.Generic;

namespace BookStore.Contract.ResponseModels
{
    public class TagResponseModel
    {
        public Guid TagId { get; set; }
        public string TagName { get; set; }
        public List<BookResponseModel> Books { get; set; }
        public bool Selected { get; set; }
    }
}