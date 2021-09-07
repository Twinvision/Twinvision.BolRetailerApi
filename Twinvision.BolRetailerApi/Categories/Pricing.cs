using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all functions used to communicate to BOL about Pricing
    /// </summary>
    public class Pricing : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Pricing(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        /// <summary>
        /// V4 BETA: Retrieve retail price information for an EAN.
        /// Currently this endpoint only supports the allowable retail price and can support the following use cases:
        ///1) EANs that have been unpublished due to price related reasons can be checked against this endpoint.
        ///2) Requesting the allowable retail price for EANs that are not yet in your assortment can help inform price setting.
        /// </summary>
        /// <param name="ean">The EAN number associated with this product.</param>
        /// <returns>A list of retail prices and countries</returns>
        public async Task<RetailPricing> GetRetailPricingInformationForEAN(string ean)
        {
            var response = await Get($"/pricing/retail-prices/{ean}", acceptHeader: AcceptHeaders.V5Json).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<RetailPricing>(response).ConfigureAwait(false);
        }
    }
}