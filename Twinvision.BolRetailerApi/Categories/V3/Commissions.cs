
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all functions used to communicate to BOL about commisions
    /// </summary>
    public class Commisions : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Commisions(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        /// <summary>
        /// Gets all commissions and possible reductions by EAN, condition and optionally price. 
        /// No more than 100 EAN`s can be sent in a single request.
        /// </summary>
        /// <param name="queries">Object that holds properties which get queried</param>
        /// <returns></returns>
        public async Task<CommissionsContainer> GetCommissions(CommissionQueriesContainer queries)
        {
            using (var content = BolApiHelper.BuildContentFromObject(queries))
            {
                var response = await Post("/commission", content);
                return await BolApiHelper.GetContentFromResponse<CommissionsContainer>(response);
            }
        }

        /// <summary>
        /// Commissions can be filtered by condition, which defaults to NEW. 
        /// If price is provided, the exact commission amount will also be calculated.
        /// </summary>
        /// <param name="ean">The EAN number associated with this product.</param>
        /// <param name="condition">The condition of the offer.</param>
        /// <param name="price">The price of the product with a period as a decimal separator. The price should always have two decimals precision.</param>
        /// <returns></returns>
        public async Task<Commission> GetCommissionByEAN(string ean, string condition = null, decimal? price = null)
        {
            using (var client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>();
                if(condition != null)
                {
                    parameters.Add(nameof(condition), condition);
                }
                if (price != null)
                {
                    parameters.Add(nameof(price), ((decimal)price).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                }
                var response = await Get($"/commission/{ean}", parameters);
                return await BolApiHelper.GetContentFromResponse<Commission>(response);
            }
        }
    }
}