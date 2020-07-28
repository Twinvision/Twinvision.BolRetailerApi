using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twinvision.BolRetailerApi.Containers;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all functions used to communicate to BOL about reductions
    /// </summary>
    public class Reductions : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Reductions(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        public async Task<ReductionCSVContainer> GetReductionsCSV()
        {
            var response = await Get("/reductions", acceptHeader: AcceptHeaders.V3Csv).ConfigureAwait(false);
            var reductionCsvContainer = new ReductionCSVContainer()
            {
                LatestReductionFileName = response.Content.Headers.ContentDisposition.FileName,
                ReductionsCsv = await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            };
            return reductionCsvContainer;
        }

        public async Task<string> GetLatestReductionFileName()
        {
            var response = await Get("/reductions/latest", acceptHeader: AcceptHeaders.V3Csv).ConfigureAwait(false);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
