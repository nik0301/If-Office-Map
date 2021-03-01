using System;
using Xunit;
using Object = OfficeMap.Data.Models.Object;

namespace OfficeMap.Data.Tests
{
    public class ObjectRepoTests : AbstractBaseTests
    {
        private readonly ObjectRepo repo;

        public ObjectRepoTests()
        {
            repo = new ObjectRepo(GetDbOptions());
        }

        public Object AddNewObject()
        {
            var floorRepoTests = new FloorRepoTests();
            var floor = floorRepoTests.AddNewFloor();
            var employeeRepoTests = new EmployeeRepoTests();
            var employee = employeeRepoTests.AddNewEmployee();
            var svgTypeRepoTests = new SvgTypeRepoTests();
            var svgType = svgTypeRepoTests.AddNewSvgType();
            var objectTypeRepoTests = new ObjectTypeRepoTests();
            var objectType = objectTypeRepoTests.AddNewObjectType();

            var rnd = new Random();

            var obj = new Object
            {
                EmployeeId = employee.Id,
                ObjectTypeId = objectType.Id,
                TopLeftX = rnd.Next(5, 100),
                TopLeftY = rnd.Next(5, 20),
                CustomWidth = rnd.Next(50, 150),
                CustomHeight = rnd.Next(40, 90),
                FloorId = floor.Id,
                SvgTypeId = svgType.Id,
            };

            repo.Add(obj);

            obj.Employee = employee;
            obj.ObjectType = objectType;

            return obj;
        }

        [Fact]
        public void When_new_object_added_Then_it_can_be_loaded_from_db()
        {
            var obj = AddNewObject();

            var objectFromDb = repo.GetById(obj.Id);

            Assert.Equal(obj.ObjectTypeId, objectFromDb.ObjectTypeId);
            Assert.Equal(obj.TopLeftX, objectFromDb.TopLeftX);
            Assert.Equal(obj.TopLeftY, objectFromDb.TopLeftY);
            Assert.Equal(obj.CustomWidth, objectFromDb.CustomWidth);
            Assert.Equal(obj.CustomHeight, objectFromDb.CustomHeight);
            Assert.Equal(obj.ObjectTypeId, objectFromDb.ObjectTypeId);
        }

        [Fact]
        public void When_floor_selected_Then_object_in_floor_object_list()
        {
            var obj = AddNewObject();

            var objects = repo.GetByFloorId(obj.FloorId);

            Assert.NotNull(objects);
            Assert.Contains(objects, o => o.Id == obj.Id);

        }

        [Fact]
        public void When_object_type_selected_Then_get_object_type_list()
        {
            var obj = AddNewObject();

            var objectType = repo.GetObjectsTypes(obj.FloorId);

            Assert.NotNull(objectType);
            Assert.Contains(objectType, o => o.Id == obj.ObjectTypeId);
        }

        [Fact]
        public void When_get_object_then_get_list_of_objects()
        {
            var obj = AddNewObject();

            var objects = repo.GetObjects(obj.FloorId, new string[]{ },  "WC", new string[] { });

            Assert.NotNull(objects);
               
        }

        [Fact]
        public void When_Get_Then_result_is_list_of_Objects()
        {
            var obj = AddNewObject();

            var objects = repo.Get();

            Assert.NotNull(objects);
            Assert.Contains(objects, o => o.Id == obj.Id);
        }

        [Fact]
        public void When_object_updated_Then_it_with_new_data_can_be_loaded_from_db()
        {
            var floorTestsRepo = new FloorRepoTests();
            var floor = floorTestsRepo.AddNewFloor();

            var obj = AddNewObject();

            obj.TopLeftX = 20;
            obj.TopLeftY = 30;
            obj.CustomWidth = 150;
            obj.CustomHeight = 120;
            obj.FloorId = floor.Id;

            repo.Update(obj);

            var objectFromDb = repo.GetById(obj.Id);

            Assert.Equal(obj.TopLeftX, objectFromDb.TopLeftX);
            Assert.Equal(obj.TopLeftY, objectFromDb.TopLeftY);
            Assert.Equal(obj.CustomWidth, objectFromDb.CustomWidth);
            Assert.Equal(obj.CustomHeight, objectFromDb.CustomHeight);
        }

        [Fact]
        public void When_object_deleted_Then_it_can_not_be_loaded_from_db()
        {
            var obj = AddNewObject();

            repo.Remove(obj);

            var objectFromDb = repo.GetById(obj.Id);

            Assert.Null(objectFromDb);
        }
    }
}