using System;
using System.Collections.Generic;

namespace prjDI01.Models
{
    public partial class TEmployee
    {
        public string FEmpId { get; set; } = null!;
        public string? FName { get; set; }
        public string? FGender { get; set; }
        public string? FMail { get; set; }
        public int? FSalary { get; set; }
        public DateTime? FEmploymentDate { get; set; }
    }
}
