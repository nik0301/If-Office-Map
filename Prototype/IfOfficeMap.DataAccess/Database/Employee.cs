using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfOfficeMap.DataAccess.Database
{
    public class Employee
    {
        [Key]
        public Guid ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] Photo { get; set; }

        public string BlobName { get; set; }

        public virtual  Workplace Workplace { get; set; }
    }
}
