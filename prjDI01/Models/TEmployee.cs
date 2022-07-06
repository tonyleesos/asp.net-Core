using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prjDI01.Models
{
    public partial class TEmployee
    {
        [Display(Name="員工編號")]
        [Required(ErrorMessage = "員工編號必填")]
        public string FEmpId { get; set; } = null!;
        [Display(Name = "員工姓名")]
        [Required(ErrorMessage = "員工姓名必填")]
        public string? FName { get; set; }
        [Display(Name = "員工性別")]
        public string? FGender { get; set; }
        [Display(Name = "員工信箱")]
        [EmailAddress(ErrorMessage = "必須符合信箱格式")]
        public string? FMail { get; set; }
        [Display(Name = "員工薪資")]
        [Range(25000,65000,ErrorMessage = "薪資範圍25000~65000")]
        public int? FSalary { get; set; }
        [Display(Name = "雇用日期")]
        [Required(ErrorMessage = "雇用日期必填")]
        [DataType(DataType.Date)]
        public DateTime? FEmploymentDate { get; set; }
    }
}
