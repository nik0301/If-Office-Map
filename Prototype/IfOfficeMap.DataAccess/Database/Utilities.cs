using System;
using System.ComponentModel.DataAnnotations;

namespace IfOfficeMap.DataAccess.Database
{
    public class Utilities
    {
        public enum UtilityType
        {
            Unknown = 0,
            Printer = 1,
            Xbox = 2, 
            Kitchen = 3,
            Restroom = 4
            
        }

        [Key]
        public Guid ID { get; set; }

        public float PositionX { get; set; }

        public float PositionY { get; set; }

        public string Name { get; set; }

        public UtilityType PlaceType { get; set; }
    }
}
