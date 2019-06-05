using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lapbase_Application.Models
{
    [Serializable]
    public class test

    {
        [Required(ErrorMessage = "username is required")]
        public String username { get; set; }
        [Required(ErrorMessage = "password is required")]
        public String password { get; set; }
        public String message { get; set; }
        
    }
}