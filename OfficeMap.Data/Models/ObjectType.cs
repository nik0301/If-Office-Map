using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeMap.Data.Models
{
    public class ObjectType
    {
        [Key]
        [MaxLength(10)]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Column("name")]
        public string Name { get; set; }

        public List<Object> Objects { get; set; }
    }
}
