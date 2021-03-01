using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeMap.Data.Models
{
    public class SvgType
    {
        [Key]
        [Column("id")]
        [MaxLength(10)]
        public string Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 3)]
        [Column("fill_color")]
        public string FillColor { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 3)]
        [Column("stroke_color")]
        public string StrokeColor { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 4)]
        [Column("draw")]
        public string Draw { get; set; }

        [Column("width")]
        public int Width { get; set; }

        [Column("height")]
        public int Height { get; set; }
    }
}
