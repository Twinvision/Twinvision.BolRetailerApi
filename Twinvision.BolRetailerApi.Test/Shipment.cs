using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Shipment
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Shipment>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];
        }

        [TestMethod]
        public async Task GetShipmentList()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Shipments.GetShipmentList(page:1, fulFilmentType: FulFilmentMethod.FBR);

            Assert.IsTrue(response.Shipments.Length == 4);
        }

        [TestMethod]
        public async Task GetShipmentById()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Shipments.GetShipmentById("914587795");

            Assert.IsTrue(response.ShipmentReference == "Shipment1");
        }
    }
}
