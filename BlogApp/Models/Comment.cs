using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models
{
    [Table(name:"tblComment")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedAt { get; set; }



        public virtual User User { get; set; }


        public virtual Post Post { get; set; }
    }
}