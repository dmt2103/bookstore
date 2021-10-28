using System;
using System.Collections.Generic;

namespace BookStore.Contract.RequestModels
{
    public class BookRequestModel
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryRequestModel Category { get; set; }
        public IEnumerable<BookTagRequestModel> BookTags { get; set; }
    }
}