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


        [TestMethod]
        public async Task GetSalesForeCast()
        {
            var salesForeCast = await bolApiCaller.Insights.GetSalesForeCast("91c28f60-ed1d-4b85-e053-828b620a4ed5", "12");
            Assert.IsTrue(salesForeCast.Name == "SALES_FORECAST");
        }

        [TestMethod]
        public async Task GetSearchTerms()
        {
            var searchTerms = await bolApiCaller.Insights.GetSearchTerms("Mondkapje", EPeriod.WEEK, 2);
            Assert.IsTrue(searchTerms.Countries.Length > 0);
        }
    }
}
