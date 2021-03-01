using OfficeMap.Data.Models;
using Xunit;

namespace OfficeMap.Data.Tests
{
    public class FloorRepoTests : AbstractBaseTests
    {
        private readonly FloorRepo repo;

        public FloorRepoTests()
        {
            repo = new FloorRepo(GetDbOptions());
        }

        public Floor AddNewFloor()
        {
            var floor = new Floor
            {
                Seq = 7,
                Title = "7th floor",
                Height = 1700,
                Width = 800
            };

            repo.Add(floor);

            return floor;
        }

        [Fact]
        public void When_new_floor_added_Then_it_can_be_loaded_from_db()
        {
            var floor = AddNewFloor();

            var floorFromDb = repo.GetById(floor.Id);

            Assert.Equal(floor.Seq, floorFromDb.Seq);
            Assert.Equal(floor.Title, floorFromDb.Title);
            Assert.Equal(floor.Height, floorFromDb.Height);
            Assert.Equal(floor.Width, floorFromDb.Width);
        }

        [Fact]
        public void When_Get_Then_result_is_list_of_Floors()
        {
            var floor = AddNewFloor();

            var floors = repo.Get();

            Assert.NotNull(floors);
            Assert.Contains(floors, f => f.Id == floor.Id);
        }

        [Fact]
        public void When_floor_updated_Then_it_with_new_data_can_be_loaded_from_db()
        {
            var floor = AddNewFloor();

            floor.Seq = 1;
            floor.Title = "First floor";
            floor.Width = 900;
            floor.Height = 1900;

            repo.Update(floor);

            var floorFromDb = repo.GetById(floor.Id);

            Assert.Equal(floor.Seq, floorFromDb.Seq);
            Assert.Equal(floor.Title, floorFromDb.Title);
            Assert.Equal(floor.Height, floorFromDb.Height);
            Assert.Equal(floor.Width, floorFromDb.Width);
        }

        [Fact]
        public void When_floor_deleted_Then_it_can_not_be_loaded_from_db()
        {
            var floor = AddNewFloor();

            repo.Remove(floor);

            var floorFromDb = repo.GetById(floor.Id);

            Assert.Null(floorFromDb);
        }
    }
}
