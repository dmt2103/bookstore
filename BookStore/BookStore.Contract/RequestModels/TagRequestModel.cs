using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Contract.RequestModels
{
    public class TagRequestModel
    {
        public Guid TagId { get; set; }
        [Required]
        public string TagName { get; set; }
        public bool Selected { get; set; }
    }
}