using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all functions used to communicate to BOL about inbounds
    /// </summary>
    public class Inbounds : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Inbounds(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }
    }
}
