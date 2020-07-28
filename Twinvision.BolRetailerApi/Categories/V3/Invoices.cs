using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all functions used to communicate to BOL about invoices
    /// </summary>
    public class Invoices : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Invoices(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        /// <summary>
        /// Gets a list of invoices, by default from the past 4 weeks. 
        /// The optional period-start and period-end parameters can be used together to retrieve invoices from a specific date range in the past, the period can be no longer than 31 days. 
        /// Invoices and their specifications can be downloaded separately in different media formats with the ‘GET an invoice by id’ and the ‘GET an invoice specification by id’ calls. 
        /// The available media types differ per invoice and are listed per invoice within the response. 
        /// Note: the media types listed in the response must be given in our standard API format.
        /// </summary>
        /// <param name="periodStartUtc">Period start date</param>
        /// <param name="periodEndUtc">Period end date</param>
        /// <returns></returns>
        public async Task<string> GetAllInvoices(DateTime? periodStartUtc = null, DateTime? periodEndUtc = null)
        {
            var queryParameters = new Dictionary<string, string>();
            if(periodStartUtc != null)
            {
                queryParameters.Add("period-start", ((DateTime)periodStartUtc).ToString("yyyy-MM-dd"));
            }
            if(periodEndUtc != null)
            {
                queryParameters.Add("period-end", ((DateTime)periodEndUtc).ToString("yyyy-MM-dd"));
            }
            if(queryParameters.Count == 0)
            {
                queryParameters = null;
            }
            var response = await Get($"/invoices", queryParameters).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an invoice by invoice id. 
        /// The available media types differ per invoice and are listed within the response from the ‘GET all invoices’ call. 
        /// Note: the media types listed in the response must be given in our standard API format.
        /// </summary>
        /// <param name="invoiceId">The id of the invoice</param>
        /// <returns></returns>
        public async Task<string> GetInvoiceById(string invoiceId)
        {
            var response = await Get($"/invoices/" + invoiceId).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an invoice specification for an invoice with a paginated list of its transactions. 
        /// The available media types differ per invoice specification and are listed within the response from the ‘GET all invoices’ call. 
        /// Note, the media types listed in the response must be given in our standard API format.
        /// </summary>
        /// <param name="invoiceId">The id of the invoice.</param>
        /// <param name="page">The page to get. Each page contains a maximum of 110.000 lines.</param>
        /// <returns></returns>
        public async Task<string> GetInvoiceSpecificationById(string invoiceId, int page = 1)
        {
            var queryParameters = new Dictionary<string, string>();
            //This query is only added when it is not the default only to make the tests work with the BOL Demo (if you pass the page query parameter in the demo environment it crashes..)
            if(page != 1)
            {
                queryParameters.Add("page", page.ToString());
            }
            var response = await Get($"/invoices/" + invoiceId + "/specification", queryParameters).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
