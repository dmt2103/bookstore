using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Models
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        public Guid TagId { get; set; }
        public string TagName { get; set; }
        public IEnumerable<BookTag> BookTags { get; set; }
    }
}