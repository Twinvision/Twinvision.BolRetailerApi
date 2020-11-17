using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Reductions
    {
        public string testClientId = null;
        public string testClientSecret = null;
        private BolApiCaller bolApiCaller;
        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Reductions>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];

            bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
        }

        [TestMethod]
        public async Task GetReductionsList()
        {
            var reductions = await bolApiCaller.Reductions.GetReductionsCSV();

            Assert.IsTrue(reductions.ReductionsCsv.StartsWith("EAN,MaximumPrice,CostReduction,StartDate,EndDate"));
        }

        [TestMethod]
        public async Task GetLatestReductionsFilename()
        {
            var reductionFileName = await bolApiCaller.Reductions.GetLatestReductionFileName();

            Assert.IsTrue(reductionFileName == "Verlaging_Bemiddelingsbijdrage_04052018_0005.csv");
        }

        [TestMethod]
        public async Task IsReductionFileNameTheSame()
        {
            var reductions = await bolApiCaller.Reductions.GetReductionsCSV();
            var reductionFileName = await bolApiCaller.Reductions.GetLatestReductionFileName();

            Assert.AreEqual(reductions.LatestReductionFileName, reductionFileName);
        }
    }
}
