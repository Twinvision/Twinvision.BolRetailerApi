using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
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
    }
}
