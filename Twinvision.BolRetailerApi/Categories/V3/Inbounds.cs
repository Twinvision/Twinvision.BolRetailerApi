using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.Containers;

namespace Twinvision.BolRetailerApi
{
    public enum InboundState { None, Draft, PreAnnounced, ArrivedAtWH, Cancelled };

    /// <summary>
    /// Contains all functions used to communicate to BOL about inbounds
    /// </summary>
    public class Inbounds : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Inbounds(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        public async Task<InboundsContainer> GetInboundShipmentList(int page = 1, InboundState state = InboundState.None, string reference = null, string bskuNumber = null, DateTime? creationStart = null, DateTime? creationEnd = null)
        {
            var queryParameters = new Dictionary<string, string>()
            {
                { "page", page.ToString() }
            };
            if (state != InboundState.None)
            {
                queryParameters.Add("state", state.ToString());
            }
            if (reference != null)
            {
                queryParameters.Add("reference", reference);
            }
            if (bskuNumber != null)
            {
                queryParameters.Add("bsku", bskuNumber);
            }
            if (creationStart != null)
            {
                queryParameters.Add("creation-start", ((DateTime)creationStart).ToString("yyyy-MM-dd"));
            }
            if (creationEnd != null)
            {
                queryParameters.Add("creation-end", ((DateTime)creationEnd).ToString("yyyy-MM-dd"));
            }
            var response = await Get("/inbounds", queryParameters);
            return await BolApiHelper.GetContentFromResponse<InboundsContainer>(response);
        }

        public async Task<StatusResponse> PostInboundShipment(InboundShipmentContainer inboundShipment)
        {
            using (var content = BolApiHelper.BuildContentFromObject(inboundShipment))
            {
                var response = await Post("/inbounds", content);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response);
            }
        }

        public async Task<DeliveryWindowsResponse> GetDeliveryWindowsForNewInboundShipments(DateTime? deliveryDate = null, int itemsToSendCount = 1)
        {
            var queryParameters = new Dictionary<string, string>()
            {
                { "items-to-send", itemsToSendCount.ToString() }
            };
            if (deliveryDate != null)
            {
                queryParameters.Add("delivery-date", ((DateTime)deliveryDate).ToString("yyyy-MM-dd"));
            }
            var response = await Get("/inbounds/delivery-windows", queryParameters);
            return await BolApiHelper.GetContentFromResponse<DeliveryWindowsResponse>(response);
        }

        public async Task<FBBTransporterListContainer> GetFBBTransportersList()
        {
            var response = await Get("/inbounds/fbb-transporters");
            return await BolApiHelper.GetContentFromResponse<FBBTransporterListContainer>(response);
        }

        public async Task<string> GetFBBProductLabelsByEAN(ProductLabelsContainer productLabelsContainer)
        {
            using (var content = BolApiHelper.BuildContentFromObject(productLabelsContainer))
            {
                var response = await Post("/inbounds/productlabels", content, acceptHeader: AcceptHeaders.V3Pdf);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<Inbound> GetInboundById(long inboundId)
        {
            var response = await Get("/inbounds/" + inboundId.ToString());
            return await BolApiHelper.GetContentFromResponse<Inbound>(response);
        }

        public async Task<string> GetPackingListByInboundId(long inboundId)
        {
            var response = await Get("/inbounds/" + inboundId.ToString() + "/packinglist", acceptHeader: AcceptHeaders.V3Pdf);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetFBBShippingLabelByInboundId(long inboundId)
        {
            var response = await Get("/inbounds/" + inboundId.ToString() + "/shippinglabel", acceptHeader: AcceptHeaders.V3Pdf);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
