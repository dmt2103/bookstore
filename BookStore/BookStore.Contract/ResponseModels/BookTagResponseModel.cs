using System;

namespace BookStore.Contract.ResponseModels
{
    public class BookTagResponseModel
    {
        public Guid BookId { get; set; }
        public BookResponseModel Book { get; set; }

        public Guid TagId { get; set; }
        public TagResponseModel Tag { get; set; }
    }
}