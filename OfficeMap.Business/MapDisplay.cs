using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using OfficeMap.Business.Models;
using OfficeMap.Data;
using OfficeMap.Data.Models;
using Object = OfficeMap.Data.Models.Object;

namespace OfficeMap.Business
{
    public class MapDisplay
    {
        private readonly FloorRepo floorRepo;
        private readonly ObjectRepo objectRepo;
        private readonly ObjectTypeRepo objectTypeRepo;
        private readonly ObjectAttributeRepo objectAttributeRepo;
        private readonly EmployeeRepo employeeRepo;
        private readonly Authorization authorization;

        // fill colors
        private const string DEFAULT_FILL_COLOR = "#ffffff";
        private const string WALL_FILL_COLOR = "#a5a5a5";
        private const string SEARCH_FILL_COLOR = "#fe821d";

        //stroke colors
        private const string DEFAULT_STROKE_COLOR = "#000000";
        private const string SVG_TYPE_STROKE_COLOR = "none";

        // css class names
        private const string ICON_CSS_CLASS = "map-icon";
        private const string WALL_CSS_CLASS = "wall";
        private const string AREA_CSS_CLASS = "area";

        private const int LETTER_WIDTH = 8;

        public MapDisplay(FloorRepo floorRepo,
                            ObjectRepo objectRepo,
                            ObjectTypeRepo objectTypeRepo,
                            ObjectAttributeRepo objectAttributeRepo,
                            EmployeeRepo employeeRepo,
                            Authorization authorization)
        {
            this.floorRepo = floorRepo;
            this.objectRepo = objectRepo;
            this.objectTypeRepo = objectTypeRepo;
            this.objectAttributeRepo = objectAttributeRepo;
            this.employeeRepo = employeeRepo;
            this.authorization = authorization;
        }

        public List<Path> GetPaths(int floorId)
        {

            floorId = floorId == 0 ? GetFloorId() : floorId;
            var objects = objectRepo.GetByFloorId(floorId);
            return UpdatePaths(objects, objects.Where(a => !a.ParentObjectId.HasValue), 0, 0).ToList();
        }

        public List<MapArea> GetMapAreas(int floorId, string search, string types, string filters, string units)
        {
            var mapAreas = new List<MapArea>();
            floorId = floorId == 0 ? GetFloorId() : floorId;
            var objects = objectRepo.GetByFloorId(floorId);

            var filteredObjectsIds = GetFilteredObjectIds(floorId, search, types, units);

            foreach (var obj in objects)
            {
                var fill = DEFAULT_FILL_COLOR;
                string objCssClass;
                var stroke = AddSvgTypeIfExists(obj, mapAreas) ? SVG_TYPE_STROKE_COLOR : DEFAULT_STROKE_COLOR;

                if ((filteredObjectsIds.Count == 0 || filteredObjectsIds.Contains(obj.Id))
                    && CheckedByFilter(obj, filteredObjectsIds.Count, filters))
                {
                    fill = SEARCH_FILL_COLOR;
                }

                switch (obj.ObjectTypeId)
                {
                    case null:
                    case "wall":
                        objCssClass = WALL_CSS_CLASS;
                        break;
                    case "colorWall":
                        fill = WALL_FILL_COLOR;
                        objCssClass = WALL_CSS_CLASS;
                        break;
                    default:
                        objCssClass = AREA_CSS_CLASS;
                        break;
                }

                mapAreas.Add(new MapArea
                {
                    Id = $"{obj.ObjectTypeId}_{obj.Id}",
                    Text = obj.SvgTypeId == null ? ShortenAreaText(obj) : "",
                    Fill = fill,
                    Stroke = stroke,
                    CssClass = objCssClass,
                    RotationAngle = obj.RotationAngle ?? 0
                });
            }

            return mapAreas;
        }

        private List<int> GetFilteredObjectIds(int floorId, string search, string types, string units)
        {
            var filteredObjectIds = new List<int>();

            if (!string.IsNullOrEmpty(search) || !string.IsNullOrEmpty(types) || !string.IsNullOrEmpty(units))
            {
                var filteredObjTypes = string.IsNullOrEmpty(types) ? new string[] { } : types.Split(",");
                var filteredUnits = string.IsNullOrEmpty(units) ? new string[] { } : units.Split(",");
                filteredObjectIds = objectRepo.GetObjects(floorId, filteredObjTypes, search, filteredUnits);
            }

            return filteredObjectIds;
        }

        private bool AddSvgTypeIfExists(Object obj, List<MapArea> mapAreas)
        {
            if (obj.SvgTypeId != null)
            {
                mapAreas.Add(new MapArea
                {
                    Id = $"{obj.ObjectTypeId}_{obj.Id}_icon",
                    Text = "",
                    Fill = obj.SvgType.FillColor,
                    Stroke = obj.SvgType.StrokeColor,
                    CssClass = ICON_CSS_CLASS,
                    RotationAngle = obj.RotationAngle ?? 0
                });

                return true;
            }

            return false;
        }

        private string ShortenAreaText(Object obj)
        {
            var title = obj.ObjectAttributes?.FirstOrDefault(oa => oa.AttributeId == "title");

            if (title == null)
            {
                return "";
            }

            var text = title.Value;
            var textWidth = text.Length * LETTER_WIDTH;

            if (obj.CustomWidth < textWidth)
            {
                if (text.Contains(" "))
                {
                    var index = text.LastIndexOf(" ");
                    text = (text[0] + text[index + 1].ToString()).ToUpper();
                }
                text = text.Substring(0, 2).ToUpper();
            }
            
            return text;
        }

        private bool CheckedByFilter(Object obj, int filteredObjectsCount, string filters)
        {
            if (!string.IsNullOrEmpty(filters))
            {
                var objFilters = filters.Split(",");
                if (objFilters.Contains("free workplaces"))
                {
                    return obj.ObjectTypeId == "workplace"
                           && obj.EmployeeId == null;
                }
            }

            return filteredObjectsCount > 0;
        }

        private int GetFloorId()
        {
            var floors = floorRepo.Get();
            return floors.Aggregate((f1, f2) => f1.Seq < f2.Seq ? f1 : f2).Id;
        }

        private IEnumerable<Path> UpdatePaths(List<Object> allObjects, IEnumerable<Object> childs, int parentTopLeftX, int parentTopLeftY)
        {
            foreach (var obj in childs)
            {
                yield return GetObjectPath(obj, parentTopLeftX, parentTopLeftY);

                if (obj.SvgTypeId != null)
                {
                    yield return GetObjectSvgTypePath(obj, parentTopLeftX, parentTopLeftY);
                }

                foreach (var child in UpdatePaths(allObjects, allObjects.Where(a => a.ParentObjectId == obj.Id), parentTopLeftX + obj.TopLeftX, parentTopLeftY + obj.TopLeftY))
                {
                    yield return child;
                }
            }
        }

        private Path GetObjectPath(Object obj, int parentTopLeftX, int parentTopLeftY)
        {
            var width = obj.CustomWidth ?? obj.SvgType.Width;
            var height = obj.CustomHeight ?? obj.SvgType.Height;

            return new Path()
            {
                Id = $"{obj.ObjectTypeId}_{obj.Id}",
                Draw = $"M {obj.TopLeftX + parentTopLeftX},{obj.TopLeftY + parentTopLeftY} l {width},0 0,{height} -{width},0 Z"
            };
        }

        private Path GetObjectSvgTypePath(Object obj, int parentTopLeftX, int parentTopLeftY)
        {
            var draw = new StringBuilder();
            var index = obj.SvgType.Draw.IndexOf("l");

            draw.Append($"M {parentTopLeftX + obj.TopLeftX},{parentTopLeftY + obj.TopLeftY} ");
            draw.Append(obj.SvgType.Draw.Substring(index));

            return new Path()
            {
                Id = $"{obj.ObjectTypeId}_{obj.Id}_icon",
                Draw = draw.ToString()
            };
        }

        public ObjectDetails GetObjectDetails(int objectId, string userIdentity)
        {
            EmployeeDetails empDetail = null;

            var obj = objectRepo.GetById(objectId);
            if (obj.ObjectTypeId != null)
            {
                obj.ObjectType = objectTypeRepo.GetById(obj.ObjectTypeId);
            }

            var objAttributesDetails = GetObjectAttributesDetails(objectId);

            if (obj.Employee != null)
            {
                obj.Employee.Unit = employeeRepo.GetUnit(obj.Employee.Id);
                empDetail = GetEmployeeDetails(obj.Employee);
            }

            var objDetails = new ObjectDetails
            {
                ObjectId = objectId,
                Type = obj.ObjectType,
                Attributes = objAttributesDetails,
                EmployeeDetails = empDetail,
                IsSuperUser = authorization.IsSuperUser(userIdentity)
            };

            return objDetails;
        }

        private List<Detail> GetObjectAttributesDetails(int objectId)
        {
            var attributesDetails = new List<Detail>();
            var attrs = objectAttributeRepo.GetObjectAttributes(objectId);

            if (attrs.Count != 0)
            {
                foreach (var objAttribute in attrs)
                {
                    attributesDetails.Add(new Detail
                    {
                        Name = objAttribute.Attribute.Name,
                        Value = objAttribute.Value
                    });
                }
            }

            return attributesDetails;
        }

        private EmployeeDetails GetEmployeeDetails(Employee employee)
        {
            if (employee == null)
            {
                return null;
            }

            var empDetails = new EmployeeDetails
            {
                
                Id = new Detail
                {
                    Name = GetPropertyDisplayName(typeof(Employee), nameof(employee.Id)),
                    Value = employee.Id.ToString()
                },

                UserIdentity = new Detail
                {
                    Name = GetPropertyDisplayName(typeof(Employee), nameof(employee.UserIdentity)),
                    Value = employee.UserIdentity
                },

                Name = new Detail
                {
                    Name = GetPropertyDisplayName(typeof(Employee), nameof(employee.Name)),
                    Value = employee.Name
                },

                Surname = new Detail
                {
                    Name = GetPropertyDisplayName(typeof(Employee), nameof(employee.Surname)),
                    Value = employee.Surname
                },

                JobTitle = new Detail
                {
                    Name = GetPropertyDisplayName(typeof(Employee), nameof(employee.JobTitle)),
                    Value = employee.JobTitle
                },

                Email = new Detail
                {
                    Name = GetPropertyDisplayName(typeof(Employee), nameof(employee.Email)),
                    Value = employee.Email
                },

                Phone = new Detail
                {
                    Name = GetPropertyDisplayName(typeof(Employee), nameof(employee.Phone)),
                    Value = employee.Phone
                },

                Unit = new Detail
                {
                    Name = GetPropertyDisplayName(typeof(Employee), nameof(employee.Unit.Name)),
                    Value = employee.Unit.Name
                },

                IsSuperUser = employee.IsSuperUser
            };

            return empDetails;
        }

        private string GetPropertyDisplayName(Type type, string propertyName)
        {
            MemberInfo property = type.GetProperty(propertyName);
            if (property.GetCustomAttribute(typeof(DisplayAttribute)) is DisplayAttribute da)
            {
                return da.Name;
            }

            return null;
        }
    }
}
