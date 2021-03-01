using OfficeMap.Data.Models;
using System.Collections.Generic;

namespace OfficeMap.Business.Models
{
    public class FloorData
    {
        public IList<Floor> Floors { get; set; }
        public Floor SelectedFloor { get; set; }
        public List<ObjectType> ObjectTypes { get; set; }
        public List<Unit> Units { get; set; }
        public bool IsSuperUser { get; set; }
    }
}
