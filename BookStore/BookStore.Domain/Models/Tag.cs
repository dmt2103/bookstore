using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookStore.Domain.Models
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        public Guid TagId { get; set; }
        [Required]
        public string TagName { get; set; }
        [JsonIgnore]
        public IEnumerable<BookTag> BookTags { get; set; }
    }
}