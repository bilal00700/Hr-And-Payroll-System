using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrAndPayrollSystem.Models
{
    public class AdminLogin
    {
        public int Id { get; set; }

        [Display(Name = "Admin Name")]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}