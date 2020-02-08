using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    [Table("Role")]
    public class Role
    {
        public Role()
        {

        }

        public Role(string name)
        {
            Name = name;
        }

        public Role(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public Role(int iD, string name, long userID, ICollection<User> users) : this(iD, name)
        {
            Users = users;
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "User 2-32 character!")]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}