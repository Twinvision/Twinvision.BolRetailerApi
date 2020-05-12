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
            throw new NotImplementedException();
        }


        [TestMethod]
        public async Task PushInboundShipment()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetDeliveryWindows()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetFBBTransporterList()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetFBBProductLabelsByEAN()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetInboundById()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetPackingListByInboundId()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task GetFBBShippinglabelByInboundId()
        {
            throw new NotImplementedException();
        }
    }
}
