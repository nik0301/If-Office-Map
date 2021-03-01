using Moq;
using OfficeMap.Data;
using OfficeMap.Data.Models;
using Xunit;

namespace OfficeMap.Business.Tests
{
    public class AuthorizationTests
    {
        private readonly Mock<EmployeeRepo> employeeRepoMock;
        private readonly Authorization authorization;

        public AuthorizationTests()
        {
            employeeRepoMock = new Mock<EmployeeRepo>(null);

            authorization = new Authorization(employeeRepoMock.Object);
        }

        [Fact]
        public void When_valid_user_Then_IsAuthorized_returns_true()
        {
            var employee = new Employee
            {
                UserIdentity = "test@if.lv",
                IsSuperUser = false
            };

            employeeRepoMock
                .Setup(r => r.GetByUId(It.IsAny<string>()))
                .Returns(employee);

            Assert.True(authorization.IsAuthorized("test@if.lv"));
        }

        [Theory]
        [InlineData("EUROPE\\TEST")]
        [InlineData("test@if.lv")]
        public void When_new_valid_user_Then_IsAuthorized_returns_true(string userIdentity)
        {
            var employee = new Employee
            {
                UserIdentity = userIdentity,
                IsSuperUser = false
            };

            employeeRepoMock
                .Setup(r => r.GetByUId(userIdentity))
                .Returns((Employee)null);

            employeeRepoMock
                .Setup(r => r.Add(It.IsAny<Employee>()));

            Assert.True(authorization.IsAuthorized(userIdentity));
            employeeRepoMock.Verify(e => e.GetByUId(userIdentity), Times.Once());
            employeeRepoMock.Verify(e => e.Add(It.Is<Employee>(emp => emp.UserIdentity == employee.UserIdentity && emp.IsSuperUser == employee.IsSuperUser)), Times.Once());
        }

        [Fact]
        public void When_non_valid_user_Then_IsAuthorized_returns_false()
        {
            employeeRepoMock
                .Setup(r => r.GetByUId("test user"))
                .Returns((Employee)null);

            Assert.False(authorization.IsAuthorized("test user"));
        }

        [Theory]
        [InlineData("EUROPE\\TEST")]
        [InlineData("test@if.lv")]
        public void When_valid_user_Then_IsSuperUser_returns_true(string userIdentity)
        {
            var employee = new Employee
            {
                UserIdentity = userIdentity,
                IsSuperUser = true
            };

            employeeRepoMock
                .Setup(r => r.GetByUId(It.IsAny<string>()))
                .Returns(employee);

            Assert.True(authorization.IsSuperUser(userIdentity));
        }

        [Fact]
        public void When_user_with_no_permission_Then_IsSuperUser_returns_false()
        {
            var userIdentity = "test@if.lv";

            employeeRepoMock
                .Setup(r => r.GetByUId(userIdentity))
                .Returns(new Employee
                {
                    UserIdentity = userIdentity,
                    IsSuperUser = false
                });

            Assert.False(authorization.IsSuperUser(userIdentity));
        }
    }
}
