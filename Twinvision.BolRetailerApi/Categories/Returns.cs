using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.Containers;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all possible interactions with bol about Returns
    /// </summary>
    public class Returns : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Returns(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        /// <summary>
        /// Get a paginated list of all returns, which are sorted by date in descending order.
        /// </summary>
        /// <param name="page">The requested page number with a pagesize of 50</param>
        /// <param name="handled">The status of the returns you wish to see, shows either handled or unhandled returns.</param>
        /// <param name="fulfilmentMethod">The fulfilment method. Fulfilled by the retailer (FBR) or fulfilled by bol.com (FBB).</param>
        /// <returns></returns>
        public async Task<ReturnsResponse> GetReturns(int page = 1, bool handled = false, FulFilmentMethod fulfilmentMethod = FulFilmentMethod.FBR)
        {
            var queryParameters = new Dictionary<string, string>()
            {
                { "page", page.ToString() },
                { "handled", handled.ToString() },
                { "fulfilment-method", fulfilmentMethod.ToString() },
            };
            var response = await Get($"/returns", queryParameters).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<ReturnsResponse>(response).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve a return based on the rma id.
        /// </summary>
        /// <param name="rmaId">The RMA (Return Merchandise Authorization) id that identifies this particular return.</param>
        /// <returns></returns>
        public async Task<ReturnsResponse> GetReturnByRMAId(int rmaId)
        {
            var response = await Get($"/returns/" + rmaId.ToString()).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<ReturnsResponse>(response).ConfigureAwait(false);
        }

        /// <summary>
        /// Allows the user to handle a return. 
        /// This can be to either handle an open return, or change the handlingResult of an already handled return. 
        /// The latter is only possible in limited scenarios, please check the returns documentation for a complete list.
        /// </summary>
        /// <param name="rmaId">The RMA (Return Merchandise Authorization) id that identifies this particular return.</param>
        /// <param name="handleReturnContainer">An object that holds the handling result and quantity of the returned product.</param>
        /// <returns></returns>
        public async Task<StatusResponse> HandleReturn(int rmaId, HandleReturnContainer handleReturnContainer)
        {
            using (var content = BolApiHelper.BuildContentFromObject(handleReturnContainer))
            {
                var response = await Put($"/returns/" + rmaId.ToString(), content).ConfigureAwait(false);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response).ConfigureAwait(false);
            }
        }
    }
}
