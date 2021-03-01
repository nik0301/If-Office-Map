using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeMap.Data.Models
{
    public class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("user_identity")]
        [StringLength(100, MinimumLength = 1)]
        public string UserIdentity { get; set;  }

        [StringLength(50)]
        [Column("name")]
        [Display(Name = "Vārds")]
        public string Name { get; set; }

        [StringLength(50)]
        [Column("surname")]
        [Display(Name = "Uzvārds")]
        public string Surname { get; set; }

        [StringLength(100)]
        [Column("email")]
        [Display(Name = "E-pasts")]
        public string Email { get; set; }

        [StringLength(50)]
        [Column("job_title")]
        [Display(Name = "Amats")]
        public string JobTitle { get; set; }

        [StringLength(50)]
        [Column("phone")]
        [Display(Name = "Tālrunis")]
        public string Phone { get; set; }

        [Column("is_super_user")]
        public bool IsSuperUser { get; set; }

        [MaxLength(10)]
        [Column("unit_id")]
        public string UnitId { get; set; }

        public Unit Unit { get; set; }

        public List<Object> Objects { get; set; }
    }
}
