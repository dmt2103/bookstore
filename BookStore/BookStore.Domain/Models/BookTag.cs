﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Models
{
    [Table("BookTag")]
    public class BookTag
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}