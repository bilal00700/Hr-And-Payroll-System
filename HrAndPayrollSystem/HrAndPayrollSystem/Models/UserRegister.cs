using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrAndPayrollSystem.Models
{
    public class UserRegister
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "System Code")]
        public string SystemCode { get; set; }

        [Display(Name = "User Category")]
        public string UserCategory { get; set; }

        public bool DpCreate { get; set; }
        public bool DpEdit { get; set; }
        public bool DpDetail { get; set; }
        public bool DpDelete { get; set; }

        public bool DgCreate { get; set; }
        public bool DgEdit { get; set; }
        public bool DgDetail { get; set; }
        public bool DgDelete { get; set; }

        public bool PmCreate { get; set; }
        public bool PmEdit { get; set; }
        public bool PmDetail { get; set; }
        public bool PmDelete { get; set; }

        public bool LcCreate { get; set; }
        public bool LcEdit { get; set; }
        public bool LcDetail { get; set; }
        public bool LcDelete { get; set; }




    }
}