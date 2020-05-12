using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    public enum CancelReason { OUT_OF_STOCK, REQUESTED_BY_CUSTOMER, BAD_CONDITION, HIGHER_SHIPCOST, INCORRECT_PRICE, NOT_AVAIL_IN_TIME, NO_BOL_GUARANTEE, ORDERED_TWICE, RETAIN_ITEM, TECH_ISSUE, UNFINDABLE_ITEM, OTHER };

    /// <summary>
    /// Contains all functions used to communicate to BOL about orders
    /// </summary>
    public class Orders : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Orders(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        /// <summary>
        /// Gets a paginated list of all open orders sorted by date in descending order.
        /// </summary>
        /// <param name="page">The requested page number with a pagesize of 50</param>
        /// <param name="fulFilmentType">The fulfilment method. Fulfilled by the retailer (FBR) or fulfilled by bol.com (FBB).</param>
        /// <returns></returns>
        public async Task<OrdersResponse> GetOpenOrders(int page = 1, FulFilmentType fulFilmentType = FulFilmentType.FBR)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "fulfilment-method", fulFilmentType.ToString() }
            };
            var response = await Get("/orders", queryParameters);
            return await BolApiHelper.GetContentFromResponse<OrdersResponse>(response);
        }

        /// <summary>
        /// Gets an order by order id.
        /// </summary>
        /// <param name="orderId">The id of the order to get.</param>
        /// <returns></returns>
        public async Task<OrderDetails> GetOrder(string orderId)
        {
            var response = await Get("/orders/" + orderId);
            return await BolApiHelper.GetContentFromResponse<OrderDetails>(response);
        }

        /// <summary>
        /// This endpoint can be used to either confirm a cancellation request by the customer or to cancel an order you yourself are unable to fulfil.
        /// </summary>
        /// <param name="orderItemId">The id of the order item to cancel.</param>
        /// <param name="cancelReason">The code representing the reason for cancellation of this item.</param>
        /// <returns></returns>
        public async Task<StatusResponse> CancelOrderByOrderItemId(string orderItemId, CancelReason cancelReason)
        {
            var newObject = new
            {
                reasonCode = cancelReason.ToString()
            };
            using (var content = BolApiHelper.BuildContentFromObject(newObject))
            {
                var response = await Put($"/orders/{orderItemId}/cancellation", content);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response);
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
        public async Task<StatusResponse> ShipOrderItem(string orderItemId, ShippingInfo shippingInfo)
        {
            using (var content = BolApiHelper.BuildContentFromObject(shippingInfo))
            {
                var response = await Put($"/orders/{orderItemId}/shipment", content);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response);
            }
        }
    }
}