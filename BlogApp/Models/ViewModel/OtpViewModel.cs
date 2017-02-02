using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ViewModel
{
    public class OtpViewModel
    {
        [Required(ErrorMessage ="ENTER OTP")]
        public int OTP { get; set; }
    }
}