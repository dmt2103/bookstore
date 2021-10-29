using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookStore.Domain.Models
{
    [Table("BookTag")]
    public class BookTag
    {
        [Required]
        public Guid BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
        [Required]
        public Guid TagId { get; set; }
        [JsonIgnore]
        public Tag Tag { get; set; }
    }
}