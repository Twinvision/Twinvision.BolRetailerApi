using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all functions used to communicate to BOL about shippinglabels
    /// </summary>
    public class ShippingLabels : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public ShippingLabels(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        //retailer/purchasable-shippinglabels/{order-item-id}

        public async Task<PurchasableShippingLabelContainer> GetShippingLabelOrderItemId(string orderItemId)
        {
            var response = await Get($"/purchasable-shippinglabels/{orderItemId}").ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<PurchasableShippingLabelContainer>(response).ConfigureAwait(false);
        }
    }
}
