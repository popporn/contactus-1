using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactUs.Web.ViewModels
{
    public class ContactUsIndexVM
    {
        [Required]
        [StringLength(140)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
    }
}