using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi
{
    public enum CancelReason { OUT_OF_STOCK, REQUESTED_BY_CUSTOMER, BAD_CONDITION, HIGHER_SHIPCOST, INCORRECT_PRICE, NOT_AVAIL_IN_TIME, NO_BOL_GUARANTEE, ORDERED_TWICE, RETAIN_ITEM, TECH_ISSUE, UNFINDABLE_ITEM, OTHER };

    /// <summary>
    /// Contains all functions used to communicate to BOL about orders
    /// </summary>
    public class Orders : BolApiHttpRequestHandler
    {
        /// <summary>
        /// Gets a paginated list of all open orders sorted by date in descending order.
        /// </summary>
        /// <param name="page">The requested page number with a pagesize of 50</param>
        /// <param name="fulFilmentType">The fulfilment method. Fulfilled by the retailer (FBR) or fulfilled by bol.com (FBB).</param>
        /// <returns></returns>
        public async Task<OrdersResponse> GetOpenOrders(int page = 1, FulFilmentMethod fulFilmentType = FulFilmentMethod.FBR)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "fulfilment-method", fulFilmentType.ToString() }
            };
            var response = await Get("/orders", queryParameters).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<OrdersResponse>(response).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an order by order id.
        /// </summary>
        /// <param name="orderId">The id of the order to get.</param>
        /// <returns></returns>
        public async Task<OrderDetails> GetOrder(string orderId)
        {
            var response = await Get("/orders/" + orderId).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<OrderDetails>(response).ConfigureAwait(false);
        }

        /// <summary>
        /// This endpoint can be used to either confirm a cancellation request by the customer or to cancel an order you yourself are unable to fulfil.
        /// </summary>
        /// <param name="orderItems">Items to cancel (use CancelReason enum)</param>
        /// <returns></returns>
        public async Task<StatusResponse> CancelOrderByOrderItemId(OrderItemCancellationContainer orderItemsContainer)
        {
            using (var content = BolApiHelper.BuildContentFromObject(orderItemsContainer))
            {
                var response = await Put($"/orders/cancellation", content).ConfigureAwait(false);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Ship a single order item within a customer order by providing shipping information. 
        /// In case you purchased a shipping label you can add the shippingLabelCode to this message. 
        /// In that case the transport element must be left empty. 
        /// If you ship the item(s) using your own transporter method you must omit the shippingLabelCode entirely.
        /// </summary>
        /// <param name="orderItemId">The order item being confirmed.</param>
        /// <param name="shippingInfo"></param>
        /// <returns></returns>
        public async Task<StatusResponse> ShipOrderItem(ShippingInfo shippingInfo)
        {
            using (var content = BolApiHelper.BuildContentFromObject(shippingInfo))
            {
                var response = await Put($"/orders/shipment", content).ConfigureAwait(false);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response).ConfigureAwait(false);
            }
        }
    }
}