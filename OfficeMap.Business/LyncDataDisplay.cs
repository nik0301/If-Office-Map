using OfficeMap.Data;
using OfficeMap.Lync;

namespace OfficeMap.Business
{
    public class LyncDataDisplay
    {
        private readonly EmployeeRepo employeeRepo;
        private readonly LyncData lyncData;

        public LyncDataDisplay(EmployeeRepo employeeRepo, LyncData lyncData)
        {
            this.employeeRepo = employeeRepo;
            this.lyncData = lyncData;
        }

        public virtual string GetLyncStatus(string email)
        {
            return lyncData.GetAvailability(email);
        }

        public byte[] GetLyncPhoto(int id)
        {
            return lyncData.GetPhoto(employeeRepo.GetById(id).Email);
        }

        public byte[] GetLyncPhoto(string uid)
        {
            return lyncData.GetPhoto(employeeRepo.GetByUId(uid).Email);
        }
    }
}
