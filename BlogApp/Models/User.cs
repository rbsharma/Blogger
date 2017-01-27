using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    [Table(name:"tblUser")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments{ get; set; }
    }
}