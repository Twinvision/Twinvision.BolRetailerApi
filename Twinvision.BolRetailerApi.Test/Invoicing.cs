using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Invoicing
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Invoicing>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];
        }

        [TestMethod]
        public async Task GetAllInvoices()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var invoices = await bolApiCaller.Invoices.GetAllInvoices();
        }

        [TestMethod]
        public async Task GetInvoiceById()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var invoices = await bolApiCaller.Invoices.GetInvoiceById("4500022543921");
        }

        [TestMethod]
        public async Task GetInvoiceSpecificationById()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Invoices.GetInvoiceSpecificationById("4500022543921");
        }
    }
}
