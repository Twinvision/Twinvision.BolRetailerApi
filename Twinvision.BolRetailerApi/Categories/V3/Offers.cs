﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all functions used to communicate to BOL about offers
    /// </summary>
    public class Offers : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Offers(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        /// <summary>
        /// Creates a new offer, and adds it to the catalog. After creation, status information can be retrieved to review if the offer is valid and published to the shop.
        /// </summary>
        /// <param name="offer">The offer to create</param>
        /// <returns></returns>
        public async Task<StatusResponse> CreateNewOffer(CreateOffer offer)
        {
            using (var content = BolApiHelper.BuildContentFromObject(offer))
            {
                var response = await Post("/offers", content);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response);
            }
        }

        /// <summary>
        /// Request an offer export file containing all offers.
        /// </summary>
        /// <param name="exportConfiguration">The file format in which to return the export. Defaults to "CSV"</param>
        /// <returns></returns>
        public async Task<StatusResponse> RequestOfferExportFile(OfferExportConfiguration exportConfiguration = null)
        {
            if (exportConfiguration == null)
            {
                exportConfiguration = new OfferExportConfiguration();
            }
            using (var content = BolApiHelper.BuildContentFromObject(exportConfiguration))
            {
                var response = await Post("/offers/export", content);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response);
            }
        }

        /// <summary>
        /// Retrieve an offer export file containing all offers.
        /// </summary>
        /// <param name="offerExportId">Unique identifier for an offer export.</param>
        /// <returns></returns>
        public async Task<string> RetrieveOfferExportFile(string offerExportId)
        {
            var response = await Get("/offers/export/" + offerExportId, acceptHeader: AcceptHeaders.V3Csv);
            return response.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Requests and Retrieves offer export file containing all offers.
        /// *Warning* 
        /// Can take up to multiple minutes to complete, depending on how fast bol creates its csv
        /// If called once subsequent calls will fail until BOL has released its delay for repeating this process (somewhere between 30 minutes - 1 hour)
        /// </summary>
        /// <param name="exportConfiguration">The file format in which to return the export. Defaults to "CSV"</param>
        /// <param name="maxMsDuration">The maximum amount of milliseconds this task is allowed to take. (overwritten by passing a cancellationToken)</param>
        /// <param name="cancellationToken">Cancellation token allowing customized cancellation configuration, overwrites maxMsDuration.</param>
        /// <returns></returns>
        public async Task<string> GetOfferExportFile(OfferExportConfiguration exportConfiguration = null, int maxMsDuration = 1200000, CancellationToken? cancellationToken = null)
        {
            CancellationToken innerCancellationToken;
            if (cancellationToken == null)
            {
                var source = new CancellationTokenSource();
                source.CancelAfter(maxMsDuration);
                innerCancellationToken = source.Token;
            }
            else
            {
                innerCancellationToken = (CancellationToken)cancellationToken;
            }
            if (exportConfiguration == null)
            {
                exportConfiguration = new OfferExportConfiguration();
            }
            var offerExportRequest = await RequestOfferExportFile(exportConfiguration);
            ProcessStatus exportStatus = null;
            var firstRequest = true;
            while (exportStatus == null || exportStatus.Status != "SUCCESS")
            {
                if (firstRequest)
                {
                    await Task.Delay(1000, innerCancellationToken);
                    firstRequest = false;
                }
                exportStatus = await BolApiCaller.ProcessStatus.GetStatusByProcessId(offerExportRequest.Id);
                if (exportStatus.Status == "FAILURE")
                {
                    throw new BolRetailerApiException(exportStatus.ErrorMessage);
                }
                if (exportStatus.Status != "SUCCESS")
                {
                    await Task.Delay(4000, innerCancellationToken);
                }
            }
            return await RetrieveOfferExportFile(exportStatus.EntityId.ToString());
        }

        /// <summary>
        /// Retrieve an offer by using the offer id provided to you when creating or listing your offers.
        /// </summary>
        /// <param name="offerId">Unique identifier for an offer.</param>
        /// <returns></returns>
        public async Task<Offer> GetOffer(string offerId)
        {
            var response = await Get("/offers/" + offerId);
            return await BolApiHelper.GetContentFromResponse<Offer>(response);
        }

        /// <summary>
        /// Use this endpoint to send an offer update. This endpoint returns a process status.
        /// </summary>
        /// <param name="offerId">Unique identifier for an offer.</param>
        /// <param name="updateOffer">Offer update container.</param>
        /// <returns></returns>
        public async Task<StatusResponse> UpdateOffer(string offerId, UpdateOffer updateOffer)
        {
            using (var content = BolApiHelper.BuildContentFromObject(updateOffer))
            {
                var response = await Put("/offers/" + offerId, content);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response);
            }
        }

        /// <summary>
        /// Delete an offer by id.
        /// </summary>
        /// <param name="offerId">Unique identifier for an offer.</param>
        /// <returns></returns>
        public async Task<StatusResponse> DeleteOffer(string offerId)
        {
            var response = await Delete("/offers/" + offerId);
            return await BolApiHelper.GetContentFromResponse<StatusResponse>(response);
        }

        /// <summary>
        /// Update price for offer by id. The flow is designed to facilitate the planned offering of bundle discounts. This is not yet available. Therefore, the ‘quantity’ field should always contain the value ‘1’, and the price should represent the single unit price.
        /// </summary>
        /// <param name="offerId">Unique identifier for an offer.</param>
        /// <param name="pricing">New pricing for the offer.</param>
        /// <returns></returns>
        public async Task<StatusResponse> UpdateOfferPrice(string offerId, Pricing pricing)
        {
            var pricingContainer = new UpdatePriceContainer(pricing);
            using (var content = BolApiHelper.BuildContentFromObject(pricingContainer))
            {
                var response = await Put($"/offers/{offerId}/price", content);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response);
            }
        }

        /// <summary>
        /// Update stock for offer by id.
        /// </summary>
        /// <param name="offerId">Unique identifier for an offer.</param>
        /// <param name="stock">New stock for the offer.</param>
        /// <returns></returns>
        public async Task<StatusResponse> UpdateOfferStock(string offerId, Stock stock)
        {
            using (var content = BolApiHelper.BuildContentFromObject(stock))
            {
                var response = await Put($"/offers/{offerId}/stock", content);
                return await BolApiHelper.GetContentFromResponse<StatusResponse>(response);
            }
        }
    }
}
