using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManagement.ViewModels
{
    public class UserViewModel
    {
   
        public long ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Use 4-50 character!")]
        public string UserName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Use 2-50 character!")]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool Status { get; set; }

        [Required]
        public int RoleID { get; set; }

    }
}