using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class ProcessStatus
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<ProcessStatus>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];
        }

        [TestMethod]
        public async Task GetProcessStatus()
        {
            var api = new BolApiCaller(testClientId, testClientSecret, true);
            var status = await api.ProcessStatus.GetStatusByProcessId("1");

            Assert.IsTrue(status.EventType == "CONFIRM_SHIPMENT");
        }

        [TestMethod]
        public async Task GetProcessStatusByEntityId()
        {
            var api = new BolApiCaller(testClientId, testClientSecret, true);
            var status = await api.ProcessStatus.GetProcessStatusByEntityAndEvent("555551", ProcessEventType.CONFIRM_SHIPMENT);

            Assert.IsTrue(status.ProcessStatuses[0].EventType == "CONFIRM_SHIPMENT");
        }

        [TestMethod]
        public async Task GetProcessStatusesByIds()
        {
            var api = new BolApiCaller(testClientId, testClientSecret, true);
            var statuses = await api.ProcessStatus.GetProcessStatusesByIds(new []{ "1", "2" });

            Assert.IsTrue(statuses.ProcessStatuses[0].EventType == "CONFIRM_SHIPMENT");
        }
    }
}
