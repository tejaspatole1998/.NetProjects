using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{

    public class Registration
    {
        [Required]
        public string name { get; set; }
        public string address { get; set; }
        public  string contact { get; set; }
        public int userID { get; set; }
        public string password { get; set; }
    }
}