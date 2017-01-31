using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ViewModel
{
    public class CommentViewModel
    {
        [Required(ErrorMessage = "Input is required")]
        public string Title { get; set; }

        public int postid { get; set; }
        
        public int userid { get; set; }

        public CommentViewModel(int postid)
        {
            this.postid = postid;
        }
        public CommentViewModel()
        {
            
        }
    }
}