using System.Collections.Generic;
using Moq;
using OfficeMap.Data;
using OfficeMap.Data.Models;
using OfficeMap.Data.Tests;
using Xunit;

namespace OfficeMap.Business.Tests
{
    public class MapDisplayTests : AbstractBaseTests
    {
        private readonly MapDisplay mapDisplay;
        private readonly Mock<FloorRepo> floorRepoMock;
        private readonly Mock<ObjectRepo> objectRepoMock;
        private readonly Mock<ObjectAttributeRepo> objectAttributeRepoMock;
        private readonly Mock<EmployeeRepo> employeeRepoMock;
        private readonly Floor floor;
        private readonly Object parentObj;
        private readonly Attribute attribute;
        private readonly Object workplaceObj;
        private readonly Object meetingObj;

        public MapDisplayTests()
        {
            floorRepoMock = new Mock<FloorRepo>(null);
            objectRepoMock = new Mock<ObjectRepo>(null);
            var objectTypeRepoMock = new Mock<ObjectTypeRepo>(null);
            objectAttributeRepoMock = new Mock<ObjectAttributeRepo>(null);
            employeeRepoMock = new Mock<EmployeeRepo>(null);
            var authorizationMock = new Mock<Authorization>(null);

            mapDisplay = new MapDisplay(
                floorRepoMock.Object,
                objectRepoMock.Object,
                objectTypeRepoMock.Object,
                objectAttributeRepoMock.Object,
                employeeRepoMock.Object,
                authorizationMock.Object);

            const string objectTypeWorkplaceId = "workplace";
            const string objectTypeMeetingId = "meeting";

            floor = new Floor
            {
                Id = 1,
                Seq = 1,
                Title = "1. stāvs",
                Height = 1000,
                Width = 1000
            };

            parentObj = new Object
            {
                Id = 1,
                CustomWidth = 500,
                CustomHeight = 900,
                FloorId = floor.Id,
                TopLeftX = 1,
                TopLeftY = 1
            };

            var svgType = new SvgType
            {
                Id = "workplace",
                Draw = "M0 0 l 0 0 z",
                FillColor = "#ffffff",
                StrokeColor = "#000000",
                Height = 30,
                Width = 20
            };

            var unit = new Unit
            {
                Id = "it",
                Name = "IT"
            };

            var employee = new Employee
            {
                Id = 1,
                Email = "test@t.t",
                JobTitle = "test",
                Name = "John",
                Surname = "Doe",
                Phone = "200000000",
                UnitId = unit.Id,
                Unit = unit
            };

            workplaceObj = new Object
            {
                Id = 2,
                TopLeftX = 1,
                TopLeftY = 1,
                FloorId = floor.Id,
                SvgTypeId = svgType.Id,
                SvgType = svgType,
                RotationAngle = 0,
                ObjectTypeId = objectTypeWorkplaceId,
                ParentObjectId = parentObj.Id,
                EmployeeId = employee.Id,
                Employee = employee
            };

            attribute = new Attribute
            {
                Id = "title",
                Name = "Nosaukums"
            };

            meetingObj = new Object
            {
                Id = 3,
                CustomWidth = 50,
                CustomHeight = 50,
                TopLeftX = 1,
                TopLeftY = 100,
                FloorId = floor.Id,
                ObjectTypeId = objectTypeMeetingId,
                ParentObjectId = parentObj.Id
            };

            authorizationMock
                .Setup(a => a.IsSuperUser(It.IsAny<string>()))
                .Returns(false);
        }

        [Fact]
        public void When_GetPaths_Then_result_is_Path_object_list()
        {
            floorRepoMock
                .Setup(r => r.Get())
                .Returns(new List<Floor> { floor });

            objectRepoMock
                .Setup(r => r.GetByFloorId(It.IsAny<int>()))
                .Returns(new List<Object> { parentObj, workplaceObj, meetingObj });

            var paths = mapDisplay.GetPaths(floor.Id);

            Assert.Contains(paths, p => p.Id == $"{workplaceObj.ObjectTypeId}_{workplaceObj.Id}");
            Assert.Contains(paths, p => p.Id == $"{meetingObj.ObjectTypeId}_{meetingObj.Id}");
        }

        [Fact]
        public void When_GetMapAreas_Then_result_is_MapArea_object_list()
        {
            objectRepoMock
                .Setup(r => r.GetByFloorId(It.IsAny<int>()))
                .Returns(new List<Object> { workplaceObj });

            objectRepoMock
                .Setup(r => r.GetObjects(floor.Id, It.IsAny<string[]>(), It.IsAny<string>(), It.IsAny<string[]>()))
                .Returns(new List<int> { workplaceObj.Id });

            var mapAreas = mapDisplay.GetMapAreas(floor.Id, workplaceObj.Employee.Name, workplaceObj.ObjectTypeId, "", workplaceObj.Employee.UnitId);

            Assert.Contains(mapAreas, ma => ma.Id == $"{workplaceObj.ObjectTypeId}_{workplaceObj.Id}");
        }

        [Fact]
        public void When_free_workplaces_Then_result_is_list_of_workplaces_without_employee()
        {
            var obj = new Object
            {
                Id = 4,
                TopLeftX = 1,
                TopLeftY = 400,
                FloorId = floor.Id,
                SvgType = workplaceObj.SvgType,
                SvgTypeId = workplaceObj.SvgTypeId,
                ObjectTypeId = workplaceObj.ObjectTypeId
            };

            objectRepoMock
                .Setup(r => r.GetByFloorId(It.IsAny<int>()))
                .Returns(new List<Object> { obj });

            objectRepoMock
                .Setup(r => r.GetObjects(floor.Id, It.IsAny<string[]>(), It.IsAny<string>(), It.IsAny<string[]>()))
                .Returns(new List<int> { obj.Id });

            var mapAreas = mapDisplay.GetMapAreas(floor.Id, "", "", "free workplaces", "");

            Assert.Contains(mapAreas, ma => ma.Id == $"{obj.ObjectTypeId}_{obj.Id}");
        }

        [Theory]
        [InlineData("Garderobeeeeeeeee", "GA")]
        [InlineData("Sapulču telpa", "ST")]
        public void When_GetMapAreas_Then_if_object_title_value_is_longer_than_object_width_result_is_two_letters(string objectText, string objectTextExpected)
        {
            var obj = meetingObj;

            var objectAttribute = new ObjectAttribute
            {
                Id = 1,
                ObjectId = meetingObj.Id,
                AttributeId = attribute.Id,
                Attribute = attribute,
                Value = objectText
            };

            obj.ObjectAttributes = new List<ObjectAttribute>
            {
                objectAttribute
            };

            objectRepoMock
                .Setup(r => r.GetByFloorId(It.IsAny<int>()))
                .Returns(new List<Object> { obj });

            objectRepoMock
                .Setup(r => r.GetObjects(floor.Id, It.IsAny<string[]>(), It.IsAny<string>(), It.IsAny<string[]>()))
                .Returns(new List<int> { obj.Id });

            var mapAreas = mapDisplay.GetMapAreas(floor.Id, objectText, "", "", "");

            Assert.Contains(mapAreas, ma => ma.Id == $"{obj.ObjectTypeId}_{obj.Id}" && ma.Text == objectTextExpected);
        }

        [Fact]
        public void When_GetObjectDetails_Then_result_is_list_of_Detail()
        {
            var objectAttrinutes = new List<ObjectAttribute>
            {
                new ObjectAttribute
                {
                    Attribute = attribute,
                    AttributeId = attribute.Id,
                    ObjectId = 1,
                    Value = "test"
                }
            };

            objectRepoMock
                .Setup(r => r.GetById(It.IsAny<int>()))
                .Returns(workplaceObj);

            objectAttributeRepoMock
                .Setup(r => r.GetObjectAttributes(It.IsAny<int>()))
                .Returns(objectAttrinutes);

            employeeRepoMock
                .Setup(r => r.GetUnit(It.IsAny<int>()))
                .Returns(workplaceObj.Employee.Unit);

            var details = mapDisplay.GetObjectDetails(workplaceObj.Id, null);

            Assert.Equal(workplaceObj.Employee.Name, details.EmployeeDetails.Name.Value);
        }
    }
}
