using OfficeMap.Data.Models;
using Xunit;

namespace OfficeMap.Data.Tests
{
    public class ObjectTypeRepoTests : AbstractBaseTests
    {
        private readonly ObjectTypeRepo repo;

        public ObjectTypeRepoTests()
        {
            repo = new ObjectTypeRepo(GetDbOptions());
        }

        public ObjectType AddNewObjectType()
        {
            var objType = repo.GetById("workplace");

            if (objType == null)
            {
                objType = new ObjectType
                {
                    Id = "workplace",
                    Name = "Darba vieta"
                };

                repo.Add(objType);
            }

            return objType;
        }

        [Fact]
        public void When_new_object_added_Then_it_can_be_loaded_from_db()
        {
            var obj = AddNewObjectType();

            var objectFromDb = repo.GetById(obj.Id);

            Assert.Equal(obj.Name, objectFromDb.Name);
        }
    }
}
