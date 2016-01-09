using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HrAndPayrollSystem.Models
{
    public class Province
    {
        [Key]
        public string PvCode { get; set; }

        public string ProvinceTitle { get; set; }
    }
}