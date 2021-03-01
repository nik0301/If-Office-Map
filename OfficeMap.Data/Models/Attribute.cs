using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeMap.Data.Models
{
    public class Attribute
    {
        [Key]
        [Column("id")]
        [MaxLength(10)]
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Column("name")]
        [DisplayName("Atribūts")]
        public string Name { get; set; }
    }
}
