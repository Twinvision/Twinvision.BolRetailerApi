using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var pricing = new Pricing(bundlePrices);
            var stock = new Stock(5, false);
            var fulfilment = new Fulfilment(FulFilmentType.FBB);
            var createOffer = new CreateOffer("9789492493804", condition, pricing, stock, fulfilment)
            {
                ReferenceCode = "Test-Api"
            };
            var result = await bolApiCaller.Offers.CreateNewOffer(createOffer);
        }

        [TestMethod]
        public async Task RequestExport()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Offers.RequestOfferExportFile();
        }

        [TestMethod]
        public async Task RetrieveExport()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Offers.RetrieveOfferExportFile("73985e00-d461-4461-80e7-d3fea8d23ef4");
        }

        [TestMethod]
        public async Task GetExport()
        {
            // Not done in test environment because it requires processing which is not supported in the test environment
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, false);
            var response = await bolApiCaller.Offers.GetOfferExportFile();
        }

        [TestMethod]
        public async Task RetrieveOffer()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Offers.GetOffer("13722de8-8182-d161-5422-4a0a1caab5c8");
        }

        [TestMethod]
        public async Task UpdateOffer()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var fulfilment = new Fulfilment(FulFilmentType.FBB);
            var offerUpdate = new UpdateOffer(fulfilment)
            {
                OnHoldByRetailer = true
            };
            var firstOffer = openOffers.First();
            var result = await bolApiCaller.Offers.UpdateOffer(firstOffer.OfferId.ToString(), offerUpdate);
        }

        [TestMethod]
        public async Task UpdateOfferPrice()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var bundlePrices = new List<BundlePrice>()
            {
                new BundlePrice(1, 6.55m)
            };
            var pricing = new Pricing(bundlePrices);
            var firstOffer = openOffers.First();
            var result = await bolApiCaller.Offers.UpdateOfferPrice(firstOffer.OfferId.ToString(), pricing);
        }

        [TestMethod]
        public async Task UpdateOfferStock()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var stock = new Stock(15, false);
            var firstOffer = openOffers.First();
            var result = await bolApiCaller.Offers.UpdateOfferStock(firstOffer.OfferId.ToString(), stock);
        }

        [TestMethod]
        public async Task DeleteOffer()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var firstOffer = openOffers.First();
            var result = await bolApiCaller.Offers.DeleteOffer(firstOffer.OfferId.ToString());
        }
    }
}
