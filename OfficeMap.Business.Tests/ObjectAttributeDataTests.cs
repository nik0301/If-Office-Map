using System.Collections.Generic;
using System.Linq;
using Moq;
using OfficeMap.Data;
using OfficeMap.Data.Models;
using Xunit;
using Attribute = OfficeMap.Data.Models.Attribute;

namespace OfficeMap.Business.Tests
{
    public class ObjectAttributeDataTests
    {
        private readonly Mock<AttributeRepo> attributeRepoMock;
        private readonly Mock<ObjectAttributeRepo> objectAttributeRepoMock;
        private readonly Mock<Authorization> authorizationMock;
        private readonly ObjectAttributeData objectAttributeData;

        public ObjectAttributeDataTests()
        {
            attributeRepoMock = new Mock<AttributeRepo>(null);
            objectAttributeRepoMock = new Mock<ObjectAttributeRepo>(null);
            authorizationMock = new Mock<Authorization>(null);
            objectAttributeData = new ObjectAttributeData(attributeRepoMock.Object, objectAttributeRepoMock.Object, authorizationMock.Object);
        }

        [Fact]
        public void When_GetObjectAttributes_with_user_who_has_not_permission_Then_throw_Exception()
        {
            authorizationMock
                .Setup(a => a.IsSuperUser(It.IsAny<string>()))
                .Returns(false);

            Assert.Throws<OfficeMapException>(() => objectAttributeData.GetObjectAttributes("test user", 1));
        }

        [Fact]
        public void When_UpdateObjectAttribute_with_user_who_has_permission_and_object_attribute_witch_not_exists_in_db_Then_throw_Exception()
        {
            authorizationMock
                .Setup(a => a.IsSuperUser(It.IsAny<string>()))
                .Returns(true);

            objectAttributeRepoMock
                .Setup(r => r.GetById(It.IsAny<int>()))
                .Returns((ObjectAttribute)null);

            Assert.Throws<OfficeMapException>(() => objectAttributeData.UpdateObjectAttribute("test user", 1, "test"));
        }

        [Fact]
        public void When_DeleteObjectAttribute_with_user_who_has_not_permission_Then_throw_Exception()
        {
            authorizationMock
                .Setup(a => a.IsSuperUser(It.IsAny<string>()))
                .Returns(false);

            Assert.Throws<OfficeMapException>(() => objectAttributeData.DeleteObjectAttribute("test user", 1));
        }

        [Fact]
        public void When_GetObjectAttributeCreate_with_user_who_has_not_permission_Then_throw_Eception()
        {
            authorizationMock
                .Setup(a => a.IsSuperUser(It.IsAny<string>()))
                .Returns(false);

            Assert.Throws<OfficeMapException>(() => objectAttributeData.GetObjectAttributeCreate("test user", 1));
        }

        [Fact]
        public void When_GetObjectAttributeCreate_with_user_who_has_permission_Then_result_is_ObjectAttributeCreate()
        {
            var attribute = new Attribute
            {
                Id = "test attr.",
                Name = "Test"
            };

            var objectAttribute = new ObjectAttribute
            {
                Id = 1,
                AttributeId = attribute.Id,
                ObjectId = 1,
                Value = "test"
            };

            authorizationMock
                .Setup(a => a.IsSuperUser(It.IsAny<string>()))
                .Returns(true);

            attributeRepoMock
                .Setup(r => r.GetNonExistingForObject(objectAttribute.ObjectId))
                .Returns(new List<Attribute> { attribute });

            var objectAttributeCreate = objectAttributeData.GetObjectAttributeCreate("test user", objectAttribute.ObjectId);

            Assert.True(objectAttributeCreate.Attributes.First().Id == attribute.Id);
            Assert.Equal(objectAttributeCreate.ObjectId, objectAttribute.Id);
        }

        [Fact]
        public void When_AddObjectAttribute_with_user_who_has_no_permission_Then_throw_Exception()
        {
            authorizationMock
                .Setup(a => a.IsSuperUser(It.IsAny<string>()))
                .Returns(false);

            Assert.Throws<OfficeMapException>(() => objectAttributeData.AddObjectAttribute("test user", 0, false, null, null, null));
        }

        [Fact]
        public void When_AddObjectAttribute_with_user_who_has_permission_Then_result_is_new_object_attribute_id()
        {
            var attribute = new Attribute
            {
                Id = "test attr.",
                Name = "test"
            };

            var objectAttribute = new ObjectAttribute
            {
                AttributeId = attribute.Id,
                ObjectId = 1,
                Value = "test"
            };

            attributeRepoMock
                .Setup(r => r.GetById(It.IsAny<string>()))
                .Returns(attribute);

            authorizationMock
                .Setup(a => a.IsSuperUser(It.IsAny<string>()))
                .Returns(true);

            objectAttributeRepoMock
                .Setup(r => r.Add(It.IsAny<ObjectAttribute>()));

            objectAttributeData.AddObjectAttribute("test user", objectAttribute.ObjectId, false, objectAttribute.AttributeId, null, objectAttribute.Value);

            objectAttributeRepoMock.Verify(o => o.Add(It.Is<ObjectAttribute>(a => a.AttributeId == "test attr." && a.Value == "test")), Times.Once());
        }
    }
}
