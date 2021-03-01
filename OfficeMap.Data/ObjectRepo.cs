using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OfficeMap.Data.Models;
using Object = OfficeMap.Data.Models.Object;

namespace OfficeMap.Data
{
    public class ObjectRepo : AbstractBaseRepository<Object, int>
    {
        public ObjectRepo(DbContextOptions options) : base(options)
        {
        }

        public override Object GetById(int id)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return db.Objects
                    .Include(o => o.Employee)
                    .FirstOrDefault(o => o.Id == id);
            }
        }

        public virtual List<Object> GetByFloorId(int floorId)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return db.Objects
                    .Include(o => o.SvgType)
                    .Include(o => o.Employee)
                    .Include(o => o.ObjectAttributes)
                    .Where(a => a.FloorId == floorId).ToList();
            }
        }

        public virtual List<ObjectType> GetObjectsTypes(int floorId)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return (from o in db.Objects
                        join type in db.ObjectTypes on o.ObjectTypeId equals type.Id
                        where o.FloorId == floorId && o.ObjectTypeId != null && o.ObjectTypeId != "wall" && o.ObjectTypeId != "colorWall"
                        orderby type.Name
                        select type)
                        .Distinct()
                        .ToList();
            }
        }

        public virtual List<int> GetObjects(int floorId, string[] types, string search, string[] units)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return db.Objects
                        .Where(o => o.FloorId == floorId
                                    && (types.Length == 0 || types.Contains(o.ObjectTypeId))
                                    && (string.IsNullOrEmpty(search)
                                        || o.ObjectAttributes.Any(oa => oa.Value.Contains(search))
                                        || o.Employee.Name.Contains(search)
                                        || o.Employee.Surname.Contains(search)
                                        || o.Employee.JobTitle.Contains(search)
                                        || o.Employee.Email.Contains(search)
                                        || o.Employee.Phone.Contains(search))
                                    && (units.Length == 0 || units.Contains(o.Employee.UnitId)))
                        .GroupBy(o => o.Id)
                        .Select(o => o.Key)
                        .ToList();
            }
        }
    }
}
