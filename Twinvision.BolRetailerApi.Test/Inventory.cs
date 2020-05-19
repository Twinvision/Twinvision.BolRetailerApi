using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Inventory
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
                .AddUserSecrets<Inventory>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];

            bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
        }


        [TestMethod]
        public async Task GetLVBOrFBBInventory()
        {
            var inventory = await bolApiCaller.Inventory.GetLVBOrFBBInventory();
        }
    }
}
