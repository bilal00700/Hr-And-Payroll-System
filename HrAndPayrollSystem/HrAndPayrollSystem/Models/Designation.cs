using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrAndPayrollSystem.Models
{
    public class Designation
    {
        [Key]
        [Column(Order = 0)]
        [MaxLength(10)]
        [HiddenInput(DisplayValue = false)]
        public string SystemCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [MinLength(4)]
        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
    }
}