using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrAndPayrollSystem.Models
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
    }
}