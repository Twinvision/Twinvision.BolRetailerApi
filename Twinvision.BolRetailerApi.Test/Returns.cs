using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Returns
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Returns>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];
        }


        [TestMethod]
        public async Task GetReturns()
        {
            var api = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await api.Returns.GetReturns();

            Assert.IsTrue(response.Returns[0].ReturnItems[0].Ean == "0634154562956");
        }

        [TestMethod]
        public async Task GetReturnByRMAId()
        {
            //Remove if Bol fixed this issue
            Assert.Inconclusive("Bol seems to expect a different content type, however this makes no sense..");

            var api = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await api.Returns.GetReturnByRMAId(86123452);

            Assert.IsTrue(response.Returns[0].ReturnItems[0].Ean == "8712626055150");
        }


        [TestMethod]
        public async Task HandleReturn()
        {
            var api = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await api.Returns.HandleReturn(86129741, new HandleReturnContainer(1, HandlingResult.RETURN_DOES_NOT_MEET_CONDITIONS));

            Assert.IsTrue(response.EventType == "HANDLE_RETURN_ITEM");
        }
    }
}
