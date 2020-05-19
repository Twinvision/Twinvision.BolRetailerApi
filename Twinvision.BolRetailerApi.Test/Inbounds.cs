using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.Containers;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Inbounds
    {
        public string testClientId = null;
        public string testClientSecret = null;

        private BolApiCaller bolApiCaller { get; set; }

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

            bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
        }


        [TestMethod]
        public async Task GetInboundShipmentList()
        {
            var shipment = await bolApiCaller.Inbounds.GetInboundShipmentList();
        }


        [TestMethod]
        public async Task PostInboundShipment()
        {
            var inboundsShipment = new InboundShipmentContainer()
            {
                Reference = "ZENDINGLVB1GVR",
                TimeSlot = new Timeslot()
                {
                    Start = DateTime.Parse("2018-04-05T12:00:00+02:00"),
                    End = DateTime.Parse("2018-04-05T17:00:00+02:00")
                },
                FbbTransporter = new FbbTransporter()
                {
                    Code = "UPS",
                    Name = "UPS"
                },
                LabellingService = false,
                Products = new Product[]
                {
                    new Product()
                    {
                        Ean = "8718526069334",
                        AnnouncedQuantity = 5
                    }
                }
            };
            var statusReponse = await bolApiCaller.Inbounds.PostInboundShipment(inboundsShipment);
        }

        [TestMethod]
        public async Task GetDeliveryWindows()
        {
            var statusResponse = await bolApiCaller.Inbounds.GetDeliveryWindowsForNewInboundShipments(DateTime.Parse("2018-05-31"));
            Assert.IsTrue(statusResponse.TimeSlots.Length > 0);
        }

        [TestMethod]
        public async Task GetFBBTransporterList()
        {
            var transporterList = await bolApiCaller.Inbounds.GetFBBTransportersList();
            Assert.IsTrue(transporterList.FbbTransporters.Length > 0);
        }

        [TestMethod]
        public async Task GetFBBProductLabelsByEAN()
        {
            var productLabelContainer = new ProductLabelsContainer(
                new ProductLabel[]
                {
                    new ProductLabel("0038781100893", 1),
                    new ProductLabel("5030917058226", 2)
                });
            var productLabel = await bolApiCaller.Inbounds.GetFBBProductLabelsByEAN(productLabelContainer);
            Assert.IsTrue(productLabel.StartsWith("THIS IS A FAKE PDF FILE"));
        }

        [TestMethod]
        public async Task GetInboundById()
        {
            var inbound = await bolApiCaller.Inbounds.GetInboundById(5850051250);
            Assert.IsTrue(inbound.Products.Length > 0);
        }

        [TestMethod]
        public async Task GetPackingListByInboundId()
        {
            var inbound = await bolApiCaller.Inbounds.GetPackingListByInboundId(5850051250);

        }

        [TestMethod]
        public async Task GetFBBShippinglabelByInboundId()
        {
            var shippingLabel = await bolApiCaller.Inbounds.GetFBBShippingLabelByInboundId(5850051250);
        }
    }
}
