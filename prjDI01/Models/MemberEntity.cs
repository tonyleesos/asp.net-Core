using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjDI01.Models
{
    [MetadataType(typeof(Member))]
    public partial class Member
    {
        [NotMapped]
        public string Role { get; set; }
    }
}
