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
    public class Commissions
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Commissions>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];
        }

        [TestMethod]
        public async Task GetCommissionByEANAsync()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var commission = await bolApiCaller.Commissions.GetCommissionByEAN("8712626055143", "GOOD", 24.50m);

            Assert.AreEqual(commission.Condition, "GOOD");
        }

        [TestMethod]
        public async Task GetCommissionByEANWithReduction()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var commission = await bolApiCaller.Commissions.GetCommissionByEAN("8718526069334", "NEW", 25.00m);

            Assert.AreEqual(commission.Condition, "NEW");
        }

        [TestMethod]
        public async Task GetMultipleCommissions()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            List<CommissionQuery> commissionQueryList = new List<CommissionQuery>
            {
                new CommissionQuery("8712626055150", "NEW", 34.99m),
                new CommissionQuery("8804269223123", "NEW", 699.95m),
                new CommissionQuery("8712626055143", "GOOD", 24.50m),
                new CommissionQuery("0604020064587", "NEW", 24.95m),
                new CommissionQuery("8718526069334", "NEW", 25.00m)
            };
            var commissionQueries = new CommissionQueriesContainer(commissionQueryList.ToArray());
            var commissionContainer = await bolApiCaller.Commissions.GetCommissions(commissionQueries);

            Assert.AreEqual(commissionContainer.Commissions.Length, 5);
        }
    }
}
