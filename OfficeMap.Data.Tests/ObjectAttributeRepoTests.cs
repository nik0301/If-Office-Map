using OfficeMap.Data.Models;
using Xunit;

namespace OfficeMap.Data.Tests
{
    public class ObjectAttributeRepoTests : AbstractBaseTests
    {
        private readonly ObjectAttributeRepo repo;

        public ObjectAttributeRepoTests()
        {
            repo = new ObjectAttributeRepo(GetDbOptions());
        }

        public ObjectAttribute AddNewObjectAttribute()
        {
            var objectRepoTests = new ObjectRepoTests();
            var attributeRepoTests = new AttributeRepoTests();

            var obj = objectRepoTests.AddNewObject();
            var attribute = attributeRepoTests.AddNewAttribute();

            var objectAttribute = new ObjectAttribute
            {
                Value = "true",
                ObjectId = obj.Id,
                AttributeId = attribute.Id
            };

            repo.Add(objectAttribute);

            objectAttribute.Attribute = attribute;
            objectAttribute.Object = obj;

            return objectAttribute;
        }

        [Fact]
        public void When_new_object_attribute_added_Then_it_can_be_loaded_from_db()
        {
            var objectAttribute = AddNewObjectAttribute();

            var objectAttributeFromDb = repo.GetById(objectAttribute.Id);

            Assert.Equal(objectAttribute.Value, objectAttributeFromDb.Value);
        }

        [Fact]
        public void When_Get_Then_result_is_list_of_ObjectsAttributes()
        {
            var objectAttribute = AddNewObjectAttribute();

            var objectsAttributes = repo.Get();

            Assert.NotNull(objectsAttributes);
            Assert.Contains(objectsAttributes, f => f.Id == objectAttribute.Id);
        }

        [Fact]
        public void When_object_attribute_updated_Then_it_with_new_data_can_be_loaded_from_db()
        {
            var objectsAttribute = AddNewObjectAttribute();
            objectsAttribute.Value = "true";

            var objectsAttributeFromDb = repo.GetById(objectsAttribute.Id);

            repo.Update(objectsAttribute);

            Assert.Equal(objectsAttribute.Value, objectsAttributeFromDb.Value);
        }

        [Fact]
        public void When_object_attribute_deleted_Then_it_can_not_be_loaded_from_db()
        {
            var objectsAttribute = AddNewObjectAttribute();

            repo.Remove(objectsAttribute);

            var objectsAttributeFromDb = repo.GetById(objectsAttribute.Id);

            Assert.Null(objectsAttributeFromDb);
        }

    }
}
