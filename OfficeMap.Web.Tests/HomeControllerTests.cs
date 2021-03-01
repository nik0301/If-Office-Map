using OfficeMap.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfficeMap.Business;
using OfficeMap.Data;
using Xunit;
using OfficeMap.Data.Tests;
using OfficeMap.Lync;

namespace OfficeMap.Web.Tests
{
    public class HomeControllerTests : AbstractBaseTests
    {
        private readonly HomeController controller;

        public HomeControllerTests()
        {
            controller = new HomeController(
                new FloorSwitch(
                    new FloorRepo(GetDbOptions()),
                    new ObjectRepo(GetDbOptions()),
                    new UnitRepo(GetDbOptions()),
                    new Authorization(
                        new EmployeeRepo(GetDbOptions()))),
                new LyncDataDisplay(
                    new EmployeeRepo(GetDbOptions()),
                    new LyncData(null)));
        }

        [Fact]
        public void When_View_is_not_null_Then_get_index()
        {
            ViewResult result = controller.Index() as ViewResult;

            Assert.NotNull(result);
        }
    }
}
