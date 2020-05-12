using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class Inventory : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Inventory(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }
    }
}
