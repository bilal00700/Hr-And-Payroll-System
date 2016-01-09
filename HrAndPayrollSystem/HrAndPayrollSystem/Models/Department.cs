using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrAndPayrollSystem.Models
{
    public class Department
    {
        [Key]
        [Column(Order = 0)]
        [MaxLength(10)]
        [HiddenInput(DisplayValue=false)]
        public string SystemCode { get; set; }
        
        [Key]
        [Column(Order = 1)]
        [MinLength(4)]
        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Group Code")]
        public string GroupCode { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Group Title")]
        public string GroupTitle { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
    }
}