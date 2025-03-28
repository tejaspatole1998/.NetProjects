using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
	public class Login
    {
        [Required]
        public string  userId { get; set; }
        public string password { get; set; }
     
    }
}