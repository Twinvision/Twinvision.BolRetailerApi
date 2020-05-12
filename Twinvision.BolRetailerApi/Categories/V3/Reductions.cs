using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class Reductions : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Reductions(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }
    }
}
