using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {

        }

        public Category(string name)
        {
            Name = name;
        }

        public Category(int id, string name)
        {
            ID = id;
            Name = name;
        }

        [Key]
        public int ID{ get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Use 2-50 characters!")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        
    }
}