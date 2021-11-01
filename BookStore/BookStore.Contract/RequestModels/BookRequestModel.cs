using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Contract.RequestModels
{
    public class BookRequestModel
    {
        public Guid BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid CategoryId { get; set; }
    }
}