using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ViewModel
{
    public class PostViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(5, ErrorMessage = "Minimum length is 5 characters")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

    }
}