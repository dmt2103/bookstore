using System;

namespace BookStore.Contract.RequestModels
{
    public class BookTagRequestModel
    {
        public Guid BookId { get; set; }
        public BookRequestModel Book { get; set; }

        public Guid TagId { get; set; }
        public TagRequestModel Tag { get; set; }
    }
}