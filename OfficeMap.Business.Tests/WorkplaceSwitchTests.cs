using Moq;
using OfficeMap.Data;
using OfficeMap.Data.Models;
using Xunit;

namespace OfficeMap.Business.Tests
{
    public class WorkplaceSwitchTests
    {
        private readonly Mock<EmployeeRepo> employeeRepoMock;
        private readonly Mock<ObjectRepo> objectRepoMock;
        private readonly Mock<WorkplaceChangeRepo> workplaceChangRepoMock;
        private readonly WorkplaceSwitch workplaceSwitch;
        private readonly Mock<Authorization> authorizationMock;

        public WorkplaceSwitchTests()
        {
            employeeRepoMock = new Mock<EmployeeRepo>(null);
            objectRepoMock = new Mock<ObjectRepo>(null);
            workplaceChangRepoMock = new Mock<WorkplaceChangeRepo>(null);
            authorizationMock = new Mock<Authorization>(null);
            workplaceSwitch = new WorkplaceSwitch(employeeRepoMock.Object, objectRepoMock.Object, workplaceChangRepoMock.Object,authorizationMock.Object);
        }

        //[Fact]
        //public void When_Get_email_Then_send_notification()
        //{
        //    var employee = new Employee
        //    {
               
        //        Id = 1,
        //        IsSuperUser = true,
        //        UserIdentity = "fafaf"

        //    };

        //    var obj = new Object
        //    {
        //        Id = 1,
        //        CustomWidth = 1,
        //        CustomHeight = 1,
        //        EmployeeId = 1
        //    };

            
        //        var workplace = new WorkplaceChange
        //        {
        //            Id = 1,
        //            NewWorkplaceId = 1,
        //            EmployeeId = 1
        //        };

        //    employeeRepoMock
        //            .Setup(e => e.GetById(It.IsAny<int>()))
        //            .Returns(employee);

        //        workplaceChangRepoMock
        //            .Setup(r => r.Add(It.IsAny<WorkplaceChange>()));
            

        //    var changePropose = workplaceSwitch.WorkplaceChangePropose(1,"test user");

        //    Assert.NotNull(changePropose);

        //}
    }
}
