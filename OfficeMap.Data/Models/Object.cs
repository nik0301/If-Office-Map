using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeMap.Data.Models
{
    public class Object
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("floor_id")]
        public int FloorId { get; set; }
        public Floor Floor { get; set; }

        [Column("parent_object_id")]
        public int? ParentObjectId { get; set; }
        public Object ParentObject { get; set; }

        [Column("svg_type_id")]
        public string SvgTypeId { get; set; }
        public SvgType SvgType { get; set; }

        [Column("object_type_id")]
        [MaxLength(10)]
        public string ObjectTypeId { get; set; }

        [Column("employee_id")]
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Column("top_left_x")]
        public int TopLeftX { get; set; }

        [Column("top_left_y")]
        public int TopLeftY { get; set; }

        [Column("custom_width")]
        public int? CustomWidth { get; set; }

        [Column("custom_height")]
        public int? CustomHeight { get; set; }

        [Column("rotation_angle")]
        public int? RotationAngle { get; set; }

        public List<ObjectAttribute> ObjectAttributes { get; set; }

        public ObjectType ObjectType { get; set; }
    }
}
