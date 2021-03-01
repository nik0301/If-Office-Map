using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeMap.Data.Models
{
    public class ObjectAttribute
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Column("value")]
        [DisplayName("Vērtība")]
        public string Value { get; set; }

        [Column("attribute_id")]
        public string AttributeId { get; set; }
        public Attribute Attribute { get; set; }

        [Column("object_id")]
        public int ObjectId { get; set; }
        public Object Object { get; set; }
    }
}
