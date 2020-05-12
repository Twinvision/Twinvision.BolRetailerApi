using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class Insights : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Insights(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }
    }
}
