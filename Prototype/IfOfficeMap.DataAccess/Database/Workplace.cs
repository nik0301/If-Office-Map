using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IfOfficeMap.DataAccess.Database
{
    public class Workplace
    {
        [Key]
        public Guid ID { get; set; }

        public float PositionX { get; set; }

        public float PositionY { get; set; }

        public string Data { get; set; }

        public string Note { get; set; }

        [IgnoreDataMember]
        public virtual Employee Employee { get; set; }
    }
}
