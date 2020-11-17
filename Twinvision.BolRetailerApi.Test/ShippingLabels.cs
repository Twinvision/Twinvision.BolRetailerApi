using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class ShippingLabels
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<ShippingLabels>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];
        }

        [TestMethod]
        public async Task GetPurchasableShippingLabel()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.ShippingLabels.GetShippingLabelOrderItemId("6702312887");

            Assert.IsTrue(response.PurchasableShippingLabels.Length == 3);
        }
    }
}
