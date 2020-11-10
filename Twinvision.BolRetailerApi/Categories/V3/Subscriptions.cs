using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all functions used to communicate to BOL about Subscriptions
    /// </summary>
    public class Subscriptions : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Subscriptions(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        /// <summary>
        /// V4 BETA: Get push notification subscriptions
        /// Retrieve a list of all configured and active push notification subscriptions.
        /// </summary>
        /// <returns></returns>
        public async Task<SubscriptionsContainer> GetPushNotificationSubscriptions()
        {
            var response = await Get($"/subscriptions", acceptHeader: AcceptHeaders.V4Json).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<SubscriptionsContainer>(response).ConfigureAwait(false);
        }

        /// <summary>
        /// V4 BETA: Create push notification subscription
        /// Create a push notification subscription for one (or more) of the available resources. The configured URL has to support https scheme.
        /// </summary>
        /// <param name="notificationSubscription">The notification subscription you want to create</param>
        /// <returns></returns>
        public async Task<StatusResponse> CreatePushNotificationSubscription(CreateNotificationSubscription notificationSubscription)
        {
            using (var content = BolApiHelper.BuildContentFromObject(notificationSubscription, AcceptHeaders.V4Json))
            {
                var response = await Post("/subscriptions", content, acceptHeader: AcceptHeaders.V4Json).ConfigureAwait(false);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// V4 BETA: Send test push notification for subscriptions
        /// Send a test push notification to all subscriptions for the provided event.
        /// </summary>
        /// <returns></returns>
        public async Task<StatusResponse> SendTestPushNotification()
        {
            using (var content = BolApiHelper.BuildContentFromObject(new object { }, AcceptHeaders.V4Json))
            {
                var response = await Post("/subscriptions", content, acceptHeader: AcceptHeaders.V4Json).ConfigureAwait(false);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// V4 BETA: Get push notification subscription by id
        /// Retrieve a configured and active push notification subscription with the provided id.
        /// </summary>
        /// <param name="subscriptionId">A unique identifier for the subscription</param>
        /// <returns></returns>
        public async Task<NotificationSubscription> GetPushNotificationSubscriptionById(int subscriptionId)
        {
            var response = await Get($"/subscriptions/{subscriptionId}", acceptHeader: AcceptHeaders.V4Json).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<NotificationSubscription>(response).ConfigureAwait(false);
        }

        /// <summary>
        /// V4 BETA: Update push notification subscription
        /// Update an existing push notification subscription with the supplied id. The configured URL has to support https scheme.
        /// </summary>
        /// <param name="subscriptionId">A unique identifier for the subscription</param>
        /// <param name="notificationSubscription"></param>
        /// <returns></returns>
        public async Task<StatusResponse> UpdatePushNotificationSubscription(int subscriptionId, CreateNotificationSubscription notificationSubscription)
        {
            using (var content = BolApiHelper.BuildContentFromObject(notificationSubscription, AcceptHeaders.V4Json))
            {
                var response = await Put($"/subscriptions/{subscriptionId}", content, acceptHeader: AcceptHeaders.V4Json).ConfigureAwait(false);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// V4 BETA: Delete push notification subscription
        /// Delete a push notification subscription with the provided id.
        /// </summary>
        /// <param name="subscriptionId">A unique identifier for the subscription</param>
        /// <returns></returns>
        public async Task<StatusResponse> DeletePushNotificationSubscription(int subscriptionId)
        {
            var response = await Delete($"/subscriptions/{subscriptionId}", acceptHeader: AcceptHeaders.V4Json).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<StatusResponse>(response).ConfigureAwait(false);
        }
    }
}
