using OfficeMap.Data;
using System.Linq;
using OfficeMap.Business.Models;

namespace OfficeMap.Business
{
    public class FloorSwitch
    {
        private readonly FloorRepo floorRepo;
        private readonly ObjectRepo objectRepo;
        private readonly UnitRepo unitRepo;
        private readonly Authorization authorization;

        public FloorSwitch(FloorRepo floorRepo, ObjectRepo objectRepo, UnitRepo unitRepo, Authorization authorization)
        {
            this.floorRepo = floorRepo;
            this.objectRepo = objectRepo;
            this.unitRepo = unitRepo;
            this.authorization = authorization;
        }

        public virtual FloorData Get(string userIdentity, int? floorId = null)
        {
            var floors = floorRepo.Get();

            // Select given floor.
            // If floor is not selected than select floor where current user is sitting
            // Or first available floor
            floorId = floorId ?? floorRepo.GetUsersFloorId(userIdentity);
            var selectedFloor = floorId.HasValue
                ? floors.FirstOrDefault(f => f.Id == floorId)
                : null;
            selectedFloor = selectedFloor ?? floors.First();

            return new FloorData
            {
                Floors = floors,
                SelectedFloor = selectedFloor,
                ObjectTypes = objectRepo.GetObjectsTypes(selectedFloor.Id),
                Units = unitRepo.GetUnits(selectedFloor.Id),
                IsSuperUser = authorization.IsSuperUser(userIdentity)
            };
        }
    }
}
