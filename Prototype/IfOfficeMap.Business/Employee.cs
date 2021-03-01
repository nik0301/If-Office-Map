using System;
using System.ComponentModel.DataAnnotations;

namespace IfOfficeMap.Business
{
    public class Employee
    {
        public Guid ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string BlobName { get; set; }

        public byte[] Photo { get; set; }
    }
}
