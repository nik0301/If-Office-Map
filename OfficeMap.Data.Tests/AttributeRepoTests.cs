using Xunit;

namespace OfficeMap.Data.Tests
{
    public class AttributeRepoTests : AbstractBaseTests
    {
        private readonly AttributeRepo repo;

        public AttributeRepoTests()
        {
            repo = new AttributeRepo(GetDbOptions());
        }

        public Models.Attribute AddNewAttribute()
        {
            var attribute = repo.GetById("test att.");

            if (attribute == null)
            {
                attribute = new Models.Attribute
                {
                    Id = "test att.",
                    Name = "text"
                };

                repo.Add(attribute);
            }

            return attribute;
        }

        [Fact]
        public void When_new_attribute_added_Then_it_can_be_loaded_from_db()
        {
            var attribute = AddNewAttribute();

            var attributeFromDb = repo.GetById(attribute.Id);

            Assert.Equal(attribute.Name, attributeFromDb.Name);
        }


        [Fact]
        public void When_Get_Then_result_is_list_of_attributes()
        {
            var attribute = AddNewAttribute();

            var attributes = repo.Get();

            Assert.NotNull(attributes);
            Assert.Contains(attributes, f => f.Id == attribute.Id);
        }

        [Fact]
        public void When_attribute_updated_Then_it_with_new_data_can_be_loaded_from_db()
        {
            var attribute = AddNewAttribute();
            attribute.Name = "text123";

            repo.Update(attribute);

            var attributeFromDb = repo.GetById(attribute.Id);

            Assert.Equal(attribute.Name, attributeFromDb.Name);
        }
    }
}