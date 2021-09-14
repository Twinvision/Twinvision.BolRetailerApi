using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Offers
    {
        List<CsvOffer> openOffers;

        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }

        [TestInitialize]
        public async Task Initialize()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Offers>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];

            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var csvFile = await bolApiCaller.Offers.RetrieveOfferExportFile("73985e00-d461-4461-80e7-d3fea8d23ef4");
            openOffers = CsvConverter.ConvertToObjectList<CsvOffer>(csvFile);
            await Task.Delay(500);
        }

        [TestMethod]
        public async Task CreateOffer()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var condition = new Condition(ConditionName.GOOD);
            var bundlePrices = new List<BundlePrice>
            {
                new BundlePrice(1, 5.55m)
            };
            var pricing = new PricingContainer(bundlePrices);
            var stock = new Stock(5, false);
            var fulfilment = new SmallFulfilment(FulFilmentMethod.FBB);
            var createOffer = new CreateOffer("9789492493804", condition, pricing, stock, fulfilment)
            {
                Reference = "Test-Api"
            };
            var result = await bolApiCaller.Offers.CreateNewOffer(createOffer);

            Assert.IsTrue(result.Description == "Create an offer with ean 9789492493804.");
        }

        [TestMethod]
        public async Task RequestExport()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Offers.RequestOfferExportFile();

            Assert.IsTrue(result.Description == "Create an offer export.");
        }

        [TestMethod]
        public async Task RetrieveExport()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Offers.RetrieveOfferExportFile("73985e00-d461-4461-80e7-d3fea8d23ef4");

            Assert.IsTrue(result.StartsWith("offerId,ean,conditionName"));
        }

        [TestMethod]
        public async Task GetExport()
        {
            // Not done in test environment because it requires processing which is not supported in the test environment
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, false);
            var response = await bolApiCaller.Offers.GetOfferExportFile();

            Assert.IsTrue(response.StartsWith("offerId,ean,conditionName,conditionCategory"));
        }

        [TestMethod]
        public async Task RetrieveOffer()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Offers.GetOffer("13722de8-8182-d161-5422-4a0a1caab5c8");

            Assert.IsTrue(result.Ean == "3165140085229");
        }

        [TestMethod]
        public async Task UpdateOffer()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var fulfilment = new SmallFulfilment(FulFilmentMethod.FBB);
            var offerUpdate = new UpdateOffer(fulfilment)
            {
                OnHoldByRetailer = true
            };
            var firstOffer = openOffers.First();
            var result = await bolApiCaller.Offers.UpdateOffer(firstOffer.OfferId.ToString(), offerUpdate);

            Assert.IsTrue(result.Description == "Update an offer with offerId 4ae7a221-65e7-a333-e620-3f8e1caab5c3.");
        }

        [TestMethod]
        public async Task UpdateOfferPrice()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var bundlePrices = new List<BundlePrice>()
            {
                new BundlePrice(1, 6.55m)
            };
            var pricing = new PricingContainer(bundlePrices);
            var firstOffer = openOffers.First();
            var result = await bolApiCaller.Offers.UpdateOfferPrice(firstOffer.OfferId.ToString(), pricing);

            Assert.IsTrue(result.Description == "Update price for offer with id 4ae7a221-65e7-a333-e620-3f8e1caab5c3.");
        }

        [TestMethod]
        public async Task UpdateOfferStock()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var stock = new Stock(15, false);
            var firstOffer = openOffers.First();
            var result = await bolApiCaller.Offers.UpdateOfferStock(firstOffer.OfferId.ToString(), stock);

            Assert.IsTrue(result.Description == "Update stock for offer with id 4ae7a221-65e7-a333-e620-3f8e1caab5c3.");
        }

        [TestMethod]
        public async Task DeleteOffer()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var firstOffer = openOffers.First();
            var result = await bolApiCaller.Offers.DeleteOffer(firstOffer.OfferId.ToString());
        }

        [TestMethod]
        public async Task RequestUnpublishedOfferReport()
        {
            //Remove if Bol fixed this issue
            Assert.Inconclusive("Bol seems to have deleted all This endpoint??");

            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Offers.RequestUnpublishedOfferReport();
        }

        [TestMethod]
        public async Task RetrieveUnpublishedOfferReport()
        {
            //Remove if Bol fixed this issue
            Assert.Inconclusive("Bol seems to have deleted all This endpoint??");

            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Offers.RetrieveUnpublishedOfferReport("3f2bb9f5-79dd-472c-aeb7-fef416b77928");
        }
    }
}
