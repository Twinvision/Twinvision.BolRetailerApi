using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
