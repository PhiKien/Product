using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    [Table("User")]
    public class User
    {
        public User()
        {

        }

        public User(string userName, string password, string name, string address, string email, string phone, DateTime createDate, bool status, int roleID)
        {
            UserName = userName;
            Password = password;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
            CreateDate = createDate;
            Status = status;
            RoleID = roleID;
        }

        public User(long iD, string userName, string password, string name, string address, string email, string phone, DateTime createDate, DateTime modifiedDate, bool status)
        {
            ID = iD;
            UserName = userName;
            Password = password;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
            CreateDate = createDate;
            ModifiedDate = modifiedDate;
            Status = status;
        }

        public User(long iD, string userName, string password, string name, string address, string email, string phone, DateTime createDate, DateTime modifiedDate, bool status, int roleID) : this(iD, userName, password, name, address, email, phone, createDate, modifiedDate, status)
        {
            RoleID = roleID;
        }

        public User(long iD, string userName, string password, string name, string address, string email, string phone, DateTime createDate, DateTime modifiedDate, bool status, int roleID, Role role)
        {
            ID = iD;
            UserName = userName;
            Password = password;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
            CreateDate = createDate;
            ModifiedDate = modifiedDate;
            Status = status;
            RoleID = roleID;
            Role = role;
        }

        public User(string userName, string password, string name, string address, string email, string phone, DateTime createDate, DateTime modifiedDate, bool status, int roleID)
        {
            UserName = userName;
            Password = password;
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
            CreateDate = createDate;
            ModifiedDate = modifiedDate;
            Status = status;
            RoleID = roleID;
        }

        [Key]
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

        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

    }
}