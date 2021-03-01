using OfficeMap.Data.Models;
using Xunit;

namespace OfficeMap.Data.Tests
{
    public class EmployeeRepoTests : AbstractBaseTests
    {
        private readonly EmployeeRepo employeeRepo;
        private readonly UnitRepo unitRepo;

        public EmployeeRepoTests()
        {
            employeeRepo = new EmployeeRepo(GetDbOptions());
            unitRepo = new UnitRepo(GetDbOptions());
        }

        public Employee AddNewEmployee()
        {
            var unit = unitRepo.GetById("it") ?? new Unit
            {
                Id = "it",
                Name = "IT"
            };

            var employee = employeeRepo.GetByUId("test");

            if (employee != null && employee.UnitId == null)
            {
                employee.Unit = unit;
                employee.UnitId = unit.Id;
                employeeRepo.Update(employee);
            }

            if (employee == null)
            {
                employee = new Employee
                {
                    Name = "Jānis",
                    Surname = "Bērziņš",
                    Email = "janisberzins@if.lv",
                    JobTitle = "programmer",
                    Phone = "+37122832269",
                    UnitId = unit.Id,
                    UserIdentity = "test",
                    IsSuperUser = false
                };

                employeeRepo.Add(employee);
            }

            return employee;
        }

        [Fact]
        public void When_new_employee_added_Then_it_can_be_loaded_from_db()
        {
            var employee = AddNewEmployee();

            var employeeFromDb = employeeRepo.GetById(employee.Id);

            Assert.Equal(employee.Name, employeeFromDb.Name);
            Assert.Equal(employee.Surname, employeeFromDb.Surname);
            Assert.Equal(employee.Email, employeeFromDb.Email);
            Assert.Equal(employee.JobTitle, employeeFromDb.JobTitle);
            Assert.Equal(employee.Phone, employeeFromDb.Phone);
            Assert.Equal(employee.UnitId, employeeFromDb.UnitId);
        }

        [Fact]
        public void When_Get_Then_result_is_list_of_Employees()
        {
            var employee = AddNewEmployee();

            var employees = employeeRepo.Get();

            Assert.NotNull(employees);
            Assert.Contains(employees, f => f.Id == employee.Id);
        }

        [Fact]
        public void When_employee_updated_Then_it_with_new_data_can_be_loaded_from_db()
        {
            var employee = AddNewEmployee();

            employee.Name = "Jānis";
            employee.Surname = "Bērziņš";
            employee.Email = "janisberzins@if.lv";
            employee.JobTitle = "programmer";
            employee.Phone = "+37122832269";
            employee.IsSuperUser = true;

            employeeRepo.Update(employee);

            var employeeFromDb = employeeRepo.GetById(employee.Id);

            Assert.Equal(employee.Name, employeeFromDb.Name);
            Assert.Equal(employee.Surname, employeeFromDb.Surname);
            Assert.Equal(employee.Email, employeeFromDb.Email);
            Assert.Equal(employee.JobTitle, employeeFromDb.JobTitle);
            Assert.Equal(employee.Phone, employeeFromDb.Phone);
        }

        [Fact]
        public void When_employee_deleted_Then_it_can_not_be_loaded_from_db()
        {
            var employee = employeeRepo.GetByUId("test_for_delete");

            if (employee == null)
            {
                employee = new Employee
                {
                    Name = "Jānis",
                    Surname = "Bērziņš",
                    Email = "janisberzins@if.lv",
                    JobTitle = "programmer",
                    Phone = "+37122832269",
                    UserIdentity = "test_for_delete"
                };

                employeeRepo.Add(employee);
            }

            employeeRepo.Remove(employee);

            var employeeFromDb = employeeRepo.GetById(employee.Id);

            Assert.Null(employeeFromDb);
        }
    }
}
