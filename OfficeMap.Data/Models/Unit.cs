using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeMap.Data.Models
{
    public class Unit
    {
        [Key]
        [MaxLength(10)]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Column("name")]
        [Display(Name = "Nodaļa")]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
