using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi;

namespace Twinvision.BolRetailerApi.Test
{
    [TestClass]
    public class Orders
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }
        [TestInitialize]
        public async Task Initialize()
        {
            await Task.Delay(500);

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Orders>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];
        }

        [TestMethod]
        public async Task GetOpenOrders()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentType.FBR);
        }

        [TestMethod]
        public async Task GetOrder()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentType.FBR);
            if (response.Orders.Length > 0)
            {
                foreach (var order in response.Orders)
                {
                    var orderResponse = await bolApiCaller.Orders.GetOrder(order.OrderId);
                }
            }
        }

        [TestMethod]
        public async Task CancelOrder()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentType.FBR);
            if (response.Orders.Length > 0)
            {
                foreach (var order in response.Orders)
                {
                    foreach (var orderItem in order.OrderItems)
                    {
                        await bolApiCaller.Orders.CancelOrderByOrderItemId(orderItem.OrderItemId, CancelReason.TECH_ISSUE);
                    }
                }
            }
        }

        [TestMethod]
        public async Task ShipOrder()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentType.FBR);
            if (response.Orders.Length > 0)
            {
                foreach (var order in response.Orders)
                {
                    foreach(var orderItem in order.OrderItems)
                    {
                        var shippingInfo = new ShippingInfo();
                        await bolApiCaller.Orders.ShipOrderItem(orderItem.OrderItemId, shippingInfo);
                        //The BOL api limits the amount of calls on this endpoint
                        await Task.Delay(100);
                    }
                }
            }
        }
    }
}
