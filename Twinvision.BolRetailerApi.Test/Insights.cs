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
        }


        [TestMethod]
        public async Task GetPerformanceIndicators()
        {
            throw new NotImplementedException();
        }
    }
}
