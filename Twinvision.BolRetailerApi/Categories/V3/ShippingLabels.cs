using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
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
            var response = await Get($"/purchasable-shippinglabels/{orderItemId}");
            return await BolApiHelper.GetContentFromResponse<PurchasableShippingLabelContainer>(response);
        }
    }
}
