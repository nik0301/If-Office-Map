using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeMap.Data.Models
{
    public class WorkplaceChange
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("new_workplace_id")]
        public int NewWorkplaceId { get; set; }

        [Column("old_workplace_id")]
        public int? OldWorkplaceId { get; set; }
        
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        
        [Column("approval_date")]
        public DateTime? ApprovalDate { get; set; }

        public Object NewWorkplace { get; set; }
        public Object OldWorkplace { get; set; }
        public Employee Employee { get; set; }
    }
}
