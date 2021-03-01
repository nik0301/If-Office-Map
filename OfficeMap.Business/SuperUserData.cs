using System.Collections.Generic;
using OfficeMap.Data;
using OfficeMap.Data.Models;

namespace OfficeMap.Business
{
    public class SuperUserData
    {
        private readonly EmployeeRepo employeeRepo;
        private readonly Authorization authorization;
        private readonly ObjectAttributeData objectAttributeData;

        public SuperUserData(EmployeeRepo employeeRepo, Authorization authorization, ObjectAttributeData objectAttributeData)
        {
            this.employeeRepo = employeeRepo;
            this.authorization = authorization;
            this.objectAttributeData = objectAttributeData;
        }
        public IList<Employee> GetEmployees(string userIdentity, int employeeId)
        {
            objectAttributeData.CheckPermission(userIdentity);

            return employeeRepo.Get();
        }

        public void UpdateEmployeeRole(string userIdentity, int employeeId, bool value)
        {
            objectAttributeData.CheckPermission(userIdentity);

            var employee = employeeRepo.GetById(employeeId);

            if (employee == null)
            {
                throw new OfficeMapException("Nav darbinieka ar norādīto id.");
            }

            employee.IsSuperUser = value;
            employeeRepo.Update(employee);
        }
    }
}
