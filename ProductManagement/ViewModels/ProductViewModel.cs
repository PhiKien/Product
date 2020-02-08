using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagement.ViewModels
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Use 2-50 character!")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Use little more 50 character!")]
        public string Description { get; set; }

        [Required]
        [Range(1, 9999, ErrorMessage = "Quantity must be greater than 0!")]
        public int NumberInStock { get; set; }

        [Required]
        public int CategoryID { get; set; }
    }
}