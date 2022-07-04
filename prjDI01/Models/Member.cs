using System.ComponentModel.DataAnnotations;

namespace prjDI01.Models
{
    public class Member
    {
        [Display(Name="帳號")]
        [Required(ErrorMessage ="帳號必填")]
        public string Uid { get; set; }
        [Display(Name = "密碼")]
        [Required(ErrorMessage = "密碼必填")]
        public string Pwd { get; set; }
        [Display(Name = "確認密碼")]
        [Required(ErrorMessage = "確認密碼必填")]
        [Compare("Pwd", ErrorMessage = "密碼與確認密碼必須相同")]
        public string RePwd { get; set; }
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名必填")]
        public string Name { get; set; }
        [Display(Name = "信箱")]
        [EmailAddress(ErrorMessage = "信箱格式有誤")]
        public string Email { get; set; }
        [Display(Name = "個人網站")]
        [Url(ErrorMessage = "網址格式有誤")]
        public string Website { get; set; }
        [Display(Name = "薪資")]
        [Required(ErrorMessage = "薪資必填")]
        [Range(25000, 75000, ErrorMessage = "薪資介於25000~75000")]
        public int Salary { get; set; }

    }
}
