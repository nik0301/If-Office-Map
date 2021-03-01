using OfficeMap.Data;
using OfficeMap.Data.Models;

namespace OfficeMap.Business
{
    public class Authorization
    {
        private readonly EmployeeRepo employeeRepo;

        public Authorization(EmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public bool IsAuthorized(string uId)
        {
            if (employeeRepo.GetByUId(uId) != null)
            {
                return true;
            }

            var domain = "";
            var name = "";
            var surname = "";

            if (uId.Contains("@"))
            {
                var parts = uId.Split("@");

                if (parts[0].Contains("."))
                {
                    name = parts[0].Split(".")[0];
                    surname = parts[0].Split(".")[1];
                }
                domain = parts[1].Substring(0, parts[1].IndexOf("."));
            }

            if (!uId.Contains("EUROPE") && (string.IsNullOrEmpty(domain) || !domain.Equals("if")))
            {
                return false;
            }

            employeeRepo.Add(new Employee
            {
                UserIdentity = uId,
                Email = uId.Contains("@") ? uId : "",
                Name = name,
                Surname = surname,
                IsSuperUser = false,
            });

            return true;
        }

        public virtual bool IsSuperUser(string userIdentity)
        {
            var emp = employeeRepo.GetByUId(userIdentity);
            return emp != null && emp.IsSuperUser;
        }
    }
}
