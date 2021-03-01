using System.IO;
using Microsoft.Extensions.Configuration;
using Moq;
using OfficeMap.Lync;
using Xunit;

namespace OfficeMap.Business.Tests
{
    public class LyncDataTests
    {
        private readonly LyncData lyncData;

        public LyncDataTests()
        {
            var configSectionMock = new Mock<IConfigurationSection>();
            configSectionMock.SetupGet(c => c["User"])
                .Returns("ricards.maurins@if.lv");
            configSectionMock.SetupGet(c => c["Password"])
                .Returns(File.ReadAllText("LynkPsw.txt"));

            var configMock = new Mock<IConfiguration>();
            configMock.Setup(c => c.GetSection(It.IsAny<string>()))
                .Returns(configSectionMock.Object);

            var config = Config.Load(configMock.Object);

            lyncData = new LyncData(config);
        }

        [Fact(Skip = "required password")]
        public void When_get_Lync_status_Then_status_returned()
        {
            var status = lyncData.GetAvailability("nikita.dzervans@if.lv");

            Assert.NotEmpty(status);
        }
    }
}
