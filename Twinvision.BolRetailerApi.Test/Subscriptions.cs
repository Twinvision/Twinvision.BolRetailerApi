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
    public class Subscriptions
    {
        public string testClientId = null;
        public string testClientSecret = null;

        IConfiguration Configuration { get; set; }

        [TestInitialize]
        public async Task Initialize()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Offers>();

            Configuration = builder.Build();

            testClientId = Configuration["ClientId"];
            testClientSecret = Configuration["ClientSecret"];

            await Task.Delay(500);
        }

        [TestMethod]
        public async Task GetPushNotificationSubscriptions()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Subscriptions.GetPushNotificationSubscriptions();

            Assert.IsTrue(result.Subscriptions[0].Id == 1234);
        }

        [TestMethod]
        public async Task CreatePushNotificationSubscription()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var notificationSubscription = new CreateNotificationSubscription(new string[]{ "PROCESS_STATUS" }, "https://www.test.com/test");
            var result = await bolApiCaller.Subscriptions.CreatePushNotificationSubscription(notificationSubscription);

            Assert.IsTrue(result.EventType == "CREATE_SUBSCRIPTION");
            Assert.IsTrue(result.Status == "PENDING");
        }

        [TestMethod]
        public async Task SendTestPushNotification()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Subscriptions.SendTestPushNotification();

            Assert.IsTrue(result.EventType == "SEND_SUBSCRIPTION_TST_MSG");
        }

        [TestMethod]
        public async Task GetPushNotificationSubscriptionById()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Subscriptions.GetPushNotificationSubscriptionById(1234);

            Assert.IsTrue(result.Url == "https://www.example.com/push");
        }

        [TestMethod]
        public async Task UpdatePushNotificationSubscription()
        {
            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var notificationSubscription = new CreateNotificationSubscription(new string[] { "PROCESS_STATUS" }, "https://www.test.com/test");
            var result = await bolApiCaller.Subscriptions.UpdatePushNotificationSubscription(1234, notificationSubscription);

            Assert.IsTrue(result.EventType == "UPDATE_SUBSCRIPTION");
        }

        [TestMethod]
        public async Task DeletePushNotificationSubscription()
        {
            //Remove if Bol fixed this issue
            Assert.Inconclusive("Bol seems to expect a different content type, however this makes no sense..");

            var bolApiCaller = new BolApiCaller(testClientId, testClientSecret, true);
            var result = await bolApiCaller.Subscriptions.DeletePushNotificationSubscription(1234);

            Assert.IsTrue(result.EventType == "DELETE_SUBSCRIPTION");
        }
    }
}
