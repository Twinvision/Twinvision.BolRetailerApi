using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.Containers;

namespace Twinvision.BolRetailerApi
{
    public enum StockType { None, Saleable, Unsaleable }
    public enum StockAmount { None, Sufficient, Insufficient}
    /// <summary>
    /// Contains all functions used to communicate to BOL about the inventory
    /// </summary>
    public class Inventory : BolApiHttpRequestHandler
    {
        public async Task<OfferListContainer> GetLVBOrFBBInventory(int page = 1, StockType stockType = StockType.None, StockAmount stockAmount = StockAmount.None, string quantityRange = null, string query = null)
        {
            var queryParameters = new Dictionary<string, string>()
            {
                { "page", page.ToString() }
            };
            if (stockType != StockType.None)
            {
                queryParameters.Add("state", stockType.ToString().ToUpper());
            }
            if (stockAmount != StockAmount.None)
            {
                queryParameters.Add("stock", stockAmount.ToString().ToUpper());
            }
            if(quantityRange != null)
            {
                queryParameters.Add("quantity", quantityRange);
            }
            if (query != null)
            {
                queryParameters.Add("query", query);
            }
            var response = await Get("/inventory", queryParameters).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<OfferListContainer>(response).ConfigureAwait(false);
        }
    }
}
