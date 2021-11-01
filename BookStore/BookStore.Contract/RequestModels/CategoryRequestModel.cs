using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Contract.RequestModels
{
    public class CategoryRequestModel
    {
        public Guid CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}