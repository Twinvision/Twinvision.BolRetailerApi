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
    public class Pricing
    {
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

            await Task.Delay(500);
        }

        [TestMethod]
        public async Task GetRetailPricingInformationForEAN()
        {
            //Remove if Bol fixed this issue
            Assert.Inconclusive("Bol seems to expect a different content type, however this makes no sense..");

            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Pricing.GetRetailPricingInformationForEAN("0000007740404");

            Assert.IsTrue(result.RetailPrices.Count == 2);
        }
    }
}
