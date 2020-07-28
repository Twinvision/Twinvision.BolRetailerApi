using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all functions used to communicate to BOL about transports
    /// </summary>
    public class Transports : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Transports(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        public async Task<StatusResponse> AddTransportInformation(string transportId, Transport transport)
        {
            using (var content = BolApiHelper.BuildContentFromObject(transport))
            {
                var response = await Put($"/transports/{transportId}", content).ConfigureAwait(false);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response).ConfigureAwait(false);
            }
        }


        public async Task<string[]> GetShippingLabelByTransportId(string transportId)
        {
            var response = await Get($"/transports/{transportId}/shipping-label", acceptHeader: AcceptHeaders.V3Pdf).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<string[]>(response).ConfigureAwait(false);
        }
    }
}
