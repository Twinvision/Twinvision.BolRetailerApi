using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Inbounds
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Inbounds>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];
        }


        [TestMethod]
        public async Task GetInboundShipmentList()
        {
            Assert.Inconclusive("Not implemented functionality");
        }


        [TestMethod]
        public async Task PushInboundShipment()
        {
            Assert.Inconclusive("Not implemented functionality");
        }

        [TestMethod]
        public async Task GetDeliveryWindows()
        {
            Assert.Inconclusive("Not implemented functionality");
        }

        [TestMethod]
        public async Task GetFBBTransporterList()
        {
            Assert.Inconclusive("Not implemented functionality");
        }

        [TestMethod]
        public async Task GetFBBProductLabelsByEAN()
        {
            Assert.Inconclusive("Not implemented functionality");
        }

        [TestMethod]
        public async Task GetInboundById()
        {
            Assert.Inconclusive("Not implemented functionality");
        }

        [TestMethod]
        public async Task GetPackingListByInboundId()
        {
            Assert.Inconclusive("Not implemented functionality");
        }

        [TestMethod]
        public async Task GetFBBShippinglabelByInboundId()
        {
            Assert.Inconclusive("Not implemented functionality");
        }
    }
}
