using System;

namespace BookStore.Contract.ResponseModels
{
    public class BookResponseModel
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryResponseModel Category { get; set; }
    }
}