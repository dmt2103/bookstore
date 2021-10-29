using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookStore.Domain.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        [JsonIgnore]
        public IEnumerable<BookTag> BookTags { get; set; }
    }
}