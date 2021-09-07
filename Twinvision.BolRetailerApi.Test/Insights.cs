using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Insights
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
                .AddUserSecrets<Insights>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];

            bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
        }

        [TestMethod]
        public async Task GetPerformanceIndicators()
        {
            //CANCELLATIONS,FULFILMENT,PHONE_AVAILABILITY,CASE_ITEM_RATIO,TRACK_AND_TRACE,RETURNS,REVIEWS
            var indicator = await bolApiCaller.Insights.GetPerformanceIndicators(new PerformanceName[] 
            { 
                PerformanceName.CANCELLATIONS, 
                PerformanceName.FULFILMENT, 
                PerformanceName.PHONE_AVAILABILITY,
                PerformanceName.CASE_ITEM_RATIO,
                PerformanceName.TRACK_AND_TRACE,
                PerformanceName.RETURNS,
                PerformanceName.REVIEWS
            }, 2019, 10);

            Assert.IsTrue(indicator.PerformanceIndicators[0].Name == "CANCELLATIONS");
        }
    }
}
