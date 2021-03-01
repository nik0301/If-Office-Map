using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using OfficeMap.Business.Models;
using OfficeMap.Data;
using OfficeMap.Data.Models;
using Object = OfficeMap.Data.Models.Object;

namespace OfficeMap.Business
{
    public class WorkplaceSwitch
    {
        private readonly EmployeeRepo employeeRepo;
        private readonly ObjectRepo objectRepo;
        private readonly WorkplaceChangeRepo workplaceChangeRepo;
        private readonly Authorization authorization;
        private readonly string workplaceObjectId = "workplace";

        public WorkplaceSwitch(EmployeeRepo employeeRepo, ObjectRepo objectRepo, WorkplaceChangeRepo workplaceChangeRepo, Authorization authorization)
        {
            this.employeeRepo = employeeRepo;
            this.objectRepo = objectRepo;
            this.workplaceChangeRepo = workplaceChangeRepo;
            this.authorization = authorization;
        }

        public bool IsEmployeesWorkplace(int objectId, string userIdentity)
        {
            var obj = objectRepo.GetById(objectId);

            return obj.Employee != null && obj.Employee.UserIdentity == userIdentity;
        }

        public bool IsWorkplace(int id)
        {
            return objectRepo.GetById(id)?.ObjectTypeId == workplaceObjectId;
        }

        public bool IsFreeWorkplace(int id)
        {
            return objectRepo.GetById(id)?.EmployeeId == null;
        }

        public List<WorkplaceChange> GetWorkplaceChanges(int objectId)
        {
            return workplaceChangeRepo.GetByObjectId(objectId);
        }

        private void RemoveAllNotAcceptedWorkplaceProposals(int id)
        {
            var workplaceChanges = workplaceChangeRepo.GetByObjectId(id)
                .Where(w => w.ApprovalDate == null);

            foreach (var change in workplaceChanges)
            {
                workplaceChangeRepo.Remove(change.Id);
            }
        }

        public void Accept(int id, string userIdentity)
        {
            ValidateSuperUser(userIdentity);

            var workplaceChange = workplaceChangeRepo.GetById(id);

            if (workplaceChange == null)
            {
                ThrowDbNullException();
            }

            workplaceChange.ApprovalDate = DateTime.Today;
            workplaceChangeRepo.Update(workplaceChange);

            var obj = objectRepo.GetById(workplaceChange.NewWorkplaceId);
            obj.Employee = null;
            obj.EmployeeId = workplaceChange.EmployeeId;
            objectRepo.Update(obj);

            RemoveAllNotAcceptedWorkplaceProposals(obj.Id);
        }

        public void Decline(int id, string userIdentity)
        {
            ValidateSuperUser(userIdentity);

            var workplaceChange = workplaceChangeRepo.GetById(id);

            if (workplaceChange == null)
            {
                ThrowDbNullException();
            }

            workplaceChangeRepo.Remove(workplaceChange);
        }

        public WorkplaceEmployeeSetData GetWorkplaceEmployeeSetData(int objectId)
        {
            var employee = objectRepo.GetById(objectId).Employee;

            var employees = employeeRepo.Get().Where(e => e.Id != employee?.Id);

            return new WorkplaceEmployeeSetData
            {
                Objectid = objectId,
                Employees = employees.ToList()
            };
        }

        public void SetWorkplaceEmployee(int id, int employeeId, string userIdentity)
        {
            ValidateSuperUser(userIdentity);

            var obj = objectRepo.GetById(id);

            if (obj == null)
            {
                ThrowDbNullException();
            }

            obj.Employee = null;
            obj.EmployeeId = employeeId;
            objectRepo.Update(obj);

            RemoveAllNotAcceptedWorkplaceProposals(id);
        }

        private void ValidateSuperUser(string userIdentity)
        {
            if (!authorization.IsSuperUser(userIdentity))
            {
                throw new OfficeMapException("Jums nav piešķirtas tiesības veikt šādu darbību.");
            }
        }

        private void SendEmail(MailMessage message)
        {
            using (var smtp = new SmtpClient("smtp.ifint.biz"))
            {
                smtp.Send(message);
            }
        }

        public void SendNotification(Employee employee, Object workplace, int workplaceChangeId)
        {
            var message = new MailMessage
            {
                From = new MailAddress(employee.Email),
                Subject = $"Darba vietas maiņa #{workplaceChangeId}",
                IsBodyHtml = true
            };

            message.To.Add("ifjuniorschool@gmail.com");

            var url = $"http://localhost:50714/?floorId={workplace.FloorId}&search={employee.Email}";

            StringBuilder messageBody = new StringBuilder();

            messageBody.Append("Jauns darba vietas maiņas pieprasījums no darbinieka:<br/>");
            messageBody.Append($"<strong>{employee.Name} {employee.Surname}</strong><br/>");
            messageBody.Append($"{employee.Email}<br/><br/>");
            messageBody.Append("<a href=" + url + ">Skatīt kartē</a>");

            if (message.To.Count > 0)
            {
                message.Body = messageBody.ToString();
                SendEmail(message);
            }
        }

        public void WorkplaceChangePropose(int workplaceId, string userIdentity)
        {
            var workplace = objectRepo.GetById(workplaceId);
            var employee = employeeRepo.GetByUId(userIdentity);

            if (workplace == null || employee == null)
            {
                ThrowDbNullException();
            }

            int? oldWorkplaceId = null;

            if (employee.Objects != null && employee.Objects.Count > 0)
            {
                oldWorkplaceId = employee.Objects.Last().Id;
            }

            var workplaceChanges = workplaceChangeRepo.GetByEmployeeId(employee.Id);

            if (workplaceChanges.Count > 0
                && workplaceChanges.Any(w => w.NewWorkplaceId == workplaceId)
                && workplaceChanges.FirstOrDefault(w => w.NewWorkplaceId == workplaceId)?.ApprovalDate == null)
            {
                throw new OfficeMapException("Pieprasījums ir jau nosūtits!");
            }

            var workplaceChange = new WorkplaceChange
            {
                EmployeeId = employee.Id,
                NewWorkplaceId = workplaceId,
                OldWorkplaceId = oldWorkplaceId
            };

            workplaceChangeRepo.Add(workplaceChange);

            SendNotification(employee, workplace, workplaceChange.Id);
        }

        public void ReleaseWorkplace(int id, string userIdentity)
        {
            ValidateSuperUser(userIdentity);

            var obj = objectRepo.GetById(id);

            if (obj == null)
            {
                ThrowDbNullException();
            }

            obj.Employee = null;
            obj.EmployeeId = null;
            objectRepo.Update(obj);
        }

        private void ThrowDbNullException()
        {
            throw new OfficeMapException("Datubāzē trūkst datu! Lūdzu, mēģiniet vēlreiz.");
        }
    }
}
