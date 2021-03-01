using OfficeMap.Data.Models;
using Xunit;

namespace OfficeMap.Data.Tests
{
    public class UnitRepoTests : AbstractBaseTests
    {
        private readonly UnitRepo repo;

        public UnitRepoTests()
        {

            repo = new UnitRepo(GetDbOptions());
        }

        public Unit AddNewUnit()
        {
            var unit = repo.GetById("it");

            if (unit == null)
            {
                unit = new Unit
                {
                    Id = "it",
                    Name = "IT nodaļa"
                };

                repo.Add(unit);
            }

            return unit;
        }

        [Fact]
        public void When_new_unit_added_Then_it_can_be_loaded_from_db()
        {
            var unit = AddNewUnit();

            var unitFromDb = repo.GetById(unit.Id);

            Assert.Equal(unit.Name, unitFromDb.Name);
        }

        [Fact]
        public void When_get_units_Then_result_is_list_of_units()
        {
            var objectRepoTests = new ObjectRepoTests();
            var obj = objectRepoTests.AddNewObject();
            var units = repo.GetUnits(obj.FloorId);

            Assert.Contains(units, u => u.Id == obj.Employee.UnitId);
        }
    }
}
