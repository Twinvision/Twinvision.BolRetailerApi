using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    public class Shipments : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Shipments(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        /// <summary>
        /// A paginated list to retrieve all your shipments up to 3 months old. The shipments will be sorted by date in descending order.
        /// </summary>
        /// <param name="orderId">The page to get with a page size of 50.</param>
        /// <param name="page">The fulfilment method. Fulfilled by the retailer (FBR) or fulfilled by bol.com (FBB).</param>
        /// <param name="fulFilmentType">The id of the order. Only valid without fulfilment-method. The default fulfilment-method is ignored.</param>
        /// <returns></returns>
        public async Task<ShipmentsContainer> GetShipmentList(int page = 1, string orderId = "", FulFilmentType fulFilmentType = FulFilmentType.FBR)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() },
                { "fulfilment-method", fulFilmentType.ToString() },
                { "order-id", orderId }
            };
            var response = await Get($"/shipments", queryParameters);
            return await BolApiHelper.GetContentFromResponse<ShipmentsContainer>(response);
        }

        /// <summary>
        /// Retrieve a single shipment by its corresponding id.
        /// </summary>
        /// <param name="shipmentId">The id of the shipment.</param>
        /// <returns></returns>
        public async Task<DetailedShipment> GetShipmentById(string shipmentId)
        {
            var response = await Get($"/shipments/{shipmentId}");
            return await BolApiHelper.GetContentFromResponse<DetailedShipment>(response);
        }
    }
}
