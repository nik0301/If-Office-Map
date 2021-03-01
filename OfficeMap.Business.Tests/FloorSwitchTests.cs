using System.Collections.Generic;
using Moq;
using OfficeMap.Data;
using OfficeMap.Data.Models;
using OfficeMap.Data.Tests;
using Xunit;

namespace OfficeMap.Business.Tests
{
    public class FloorSwitchTests : AbstractBaseTests
    {
        private readonly FloorSwitch floorSwitch;
        private readonly Mock<FloorRepo> floorRepoMock;
        private readonly Mock<ObjectRepo> objectRepoMock;
        private readonly Mock<UnitRepo> unitRepoMock;

        private const int FIRST_FLOOR_ID = 22;
        private const int SECOND_FLOOR_ID = 23;

        public FloorSwitchTests()
        {
            floorRepoMock = new Mock<FloorRepo>(null);
            objectRepoMock = new Mock<ObjectRepo>(null);
            unitRepoMock = new Mock<UnitRepo>(null);
            var authorizationMock = new Mock<Authorization>(null);

            floorSwitch = new FloorSwitch(floorRepoMock.Object, objectRepoMock.Object, unitRepoMock.Object, authorizationMock.Object);

            authorizationMock
                .Setup(a => a.IsSuperUser(It.IsAny<string>()))
                .Returns(true);
        }

        [Fact]
        public void When_Get_with_no_selected_floor_and_not_user_with_workplace_Then_result_is_list_of_floors_and_select_first_floor()
        {
            Setup2Floors();

            // User do not belong to any floar
            floorRepoMock
                .Setup(f => f.GetUsersFloorId("Test user"))
                .Returns((int?)null);

            var floorData = floorSwitch.Get("Test user");

            Assert.Equal(2, floorData.Floors.Count);
            Assert.Equal(FIRST_FLOOR_ID, floorData.SelectedFloor.Id);
            objectRepoMock.Verify(o => o.GetObjectsTypes(FIRST_FLOOR_ID), Times.Once());
            unitRepoMock.Verify(o => o.GetUnits(FIRST_FLOOR_ID), Times.Once());
        }

        [Fact]
        public void When_Get_with_no_selected_floor_and_user_has_workplace_Then_result_is_list_of_floors_and_select_users_floor()
        {
            Setup2Floors();

            // User is linked with second floor
            floorRepoMock
                .Setup(f => f.GetUsersFloorId("Test user"))
                .Returns(SECOND_FLOOR_ID);

            var floorData = floorSwitch.Get("Test user");

            Assert.Equal(2, floorData.Floors.Count);
            Assert.Equal(SECOND_FLOOR_ID, floorData.SelectedFloor.Id);
            objectRepoMock.Verify(o => o.GetObjectsTypes(SECOND_FLOOR_ID), Times.Once());
            unitRepoMock.Verify(o => o.GetUnits(SECOND_FLOOR_ID), Times.Once());
        }

        [Fact]
        public void When_Get_with_selected_floor_Then_result_is_list_of_floors_and_select_floor()
        {
            Setup2Floors();

            // User is linked with first floor
            floorRepoMock
                .Setup(f => f.GetUsersFloorId("Test user"))
                .Returns(FIRST_FLOOR_ID);

            // Request data about second floor
            var floorData = floorSwitch.Get("Test user", SECOND_FLOOR_ID);

            Assert.Equal(2, floorData.Floors.Count);
            Assert.Equal(SECOND_FLOOR_ID, floorData.SelectedFloor.Id);
            objectRepoMock.Verify(o => o.GetObjectsTypes(SECOND_FLOOR_ID), Times.Once());
            unitRepoMock.Verify(o => o.GetUnits(SECOND_FLOOR_ID), Times.Once());
        }

        private void Setup2Floors()
        {
            var floor1 = new Floor
            {
                Id = FIRST_FLOOR_ID,
                Seq = 1,
                Title = "test",
                Height = 1,
                Width = 1
            };

            var floor2 = new Floor
            {
                Id = SECOND_FLOOR_ID,
                Seq = 1,
                Title = "test",
                Height = 1,
                Width = 1
            };

            floorRepoMock
                .Setup(f => f.Get())
                .Returns(new List<Floor>
                {
                    floor1,
                    floor2
                });

            objectRepoMock
                .Setup(r => r.GetObjectsTypes(It.IsAny<int>()))
                .Returns(new List<ObjectType>());

            unitRepoMock
                .Setup(r => r.GetUnits(It.IsAny<int>()))
                .Returns(new List<Unit>());
        }
    }
}
