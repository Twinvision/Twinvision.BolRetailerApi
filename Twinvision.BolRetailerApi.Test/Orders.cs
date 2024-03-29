using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi;
using Twinvision.BolRetailerApi.ObjectDefinitions;

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
            var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentMethod.FBR);

            Assert.IsTrue(response.Orders.Length > 0);
        }

        [TestMethod]
        public async Task GetOrder()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentMethod.FBR);
            foreach (var order in response.Orders)
            {
                var orderResponse = await bolApiCaller.Orders.GetOrder(order.OrderId);
                Assert.IsTrue(orderResponse.OrderItems.Length > 0);
            }
            Assert.IsTrue(response.Orders.Length > 0);
        }

        [TestMethod]
        public async Task OrderItemExactDeliveryDateOrLatestDeliveryDateIsFilled()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentMethod.FBR);
            foreach (var order in response.Orders)
            {
                var orderResponse = await bolApiCaller.Orders.GetOrder(order.OrderId);
                Assert.IsTrue(orderResponse.OrderItems.Length > 0);

                foreach (var orderItem in orderResponse.OrderItems)
                {
                    var eitherDateIsFilled = (orderItem.Fulfilment.ExactDeliveryDate == null || orderItem.Fulfilment.LatestDeliveryDate == null) &&
                        (orderItem.Fulfilment.ExactDeliveryDate != null || orderItem.Fulfilment.LatestDeliveryDate != null);
                    Assert.IsTrue(eitherDateIsFilled);
                }
            }
            Assert.IsTrue(response.Orders.Length > 0);
        }

        [TestMethod]
        public async Task CancelOrder()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentMethod.FBR);

            var orderItemsContainer = new OrderItemCancellationContainer();
            foreach (var order in response.Orders)
            {
                orderItemsContainer.OrderItems = new List<OrderItemCancellation>();
                var orderItem = new OrderItemCancellation()
                {
                    OrderItemId = order.OrderId,
                    ReasonCode = CancelReason.TECH_ISSUE.ToString()
                };
                orderItemsContainer.OrderItems.Add(orderItem);
                await bolApiCaller.Orders.CancelOrderByOrderItemId(orderItemsContainer);
            }

            Assert.IsTrue(response.Orders.Length > 0);
        }

        [TestMethod]
        public async Task ShipOrder()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentMethod.FBR);
            var requestWasSend = false;
            foreach (var order in response.Orders)
            {
                foreach (var orderItem in order.OrderItems)
                {
                    var shippingInfo = new ShippingInfo();
                    shippingInfo.OrderItems = new List<OrderItemIdContainer>()
                    {
                        new OrderItemIdContainer()
                        {
                            OrderItemId = orderItem.OrderItemId
                        }
                    };
                    var shipmentResponse = await bolApiCaller.Orders.ShipOrderItem(shippingInfo);
                    requestWasSend = true;
                    Assert.IsTrue(shipmentResponse.EventType == "CONFIRM_SHIPMENT");
                    //The BOL api limits the amount of calls on this endpoint
                    await Task.Delay(100);
                }
            }

            Assert.IsTrue(requestWasSend);
            Assert.IsTrue(response.Orders.Length > 0);
        }
    }
}
