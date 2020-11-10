using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Transport
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Transport>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];
        }


        [TestMethod]
        public async Task AddTransportInformation()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Transports.AddTransportInformation("358612589", new ObjectDefinitions.Transport("TNT", "3SAOLD1234567"));
        }

        [TestMethod]
        public async Task GetPurchasableShippingLabel()
        {
            Assert.Inconclusive("BOL does not support this request in its demo environment.");
        }
    }
}
