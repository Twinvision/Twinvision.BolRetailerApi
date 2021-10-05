using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.Containers;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi
{
    public enum PerformanceName { CANCELLATIONS, FULFILMENT, PHONE_AVAILABILITY, RESPONSE_TIME, CASE_ITEM_RATIO, TRACK_AND_TRACE, RETURNS, REVIEWS };
    /// <summary>
    /// Contains all functions used to communicate to BOL about insights
    /// </summary>
    public class Insights : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Insights(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        public async Task<PerformanceIndicatorsContainer> GetPerformanceIndicators(PerformanceName[] performanceNames, int year, int week)
        {
            if(performanceNames.Length == 0)
            {
                throw new BolRetailerApiException("performanceNames list was empty");
            }
            var performanceNamesString = "";
            int i = 0;
            foreach(var performanceName in performanceNames)
            {
                performanceNamesString += (i > 0 ? "," : "") + performanceName;
                i++;
            }
            var queryParameters = new Dictionary<string, string>()
            {
                { "name", performanceNamesString },
                { "year", year.ToString() },
                { "week", week.ToString() }
            };
            var response = await Get("/insights/performance/indicator", queryParameters).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<PerformanceIndicatorsContainer>(response).ConfigureAwait(false);
        }

        public async Task<SalesForeCast> GetSalesForeCast(string offerId, string weeksAhead)
        {
            var queryParameters = new Dictionary<string, string>()
            {
                { "offer-id", offerId },
                { "weeks-ahead", weeksAhead }
            };
            var response = await Get("/insights/sales-forecast", queryParameters).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<SalesForeCast>(response).ConfigureAwait(false);
        }

        public async Task<SearchTerms> GetSearchTerms(string searchTerm, EPeriod period, int numberOfPeriods, bool relatedSearchTerms = false)
        {
            var queryParameters = new Dictionary<string, string>()
            {
                { "search-term", searchTerm },
                { "period", period.ToString() },
                { "number-of-periods", numberOfPeriods.ToString() },
                { "related-search-terms", relatedSearchTerms.ToString() }
            };
            var response = await Get("/insights/search-terms", queryParameters).ConfigureAwait(false);
            return await BolApiHelper.GetContentFromResponse<SearchTerms>(response).ConfigureAwait(false);
        }
    }
}
