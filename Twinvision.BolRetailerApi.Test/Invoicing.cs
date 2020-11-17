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
        private BolApiCaller bolApiCaller;
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

            bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
        }

        [TestMethod]
        public async Task GetAllInvoices()
        {
            var invoices = await bolApiCaller.Invoices.GetAllInvoices();

            Assert.IsTrue(invoices.StartsWith("{\"invoiceListItems\""));
        }

        [TestMethod]
        public async Task GetInvoiceById()
        {
            var invoices = await bolApiCaller.Invoices.GetInvoiceById("4500022543921");

            Assert.IsTrue(invoices.StartsWith("{\"UBLVersionID\""));
        }

        [TestMethod]
        public async Task GetInvoiceSpecificationById()
        {
            var response = await bolApiCaller.Invoices.GetInvoiceSpecificationById("4500022543921");

            Assert.AreEqual(response, Resources.ResourceSpecificationValue);
        }
    }
}
