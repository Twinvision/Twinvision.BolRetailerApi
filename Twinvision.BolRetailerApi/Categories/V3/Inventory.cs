using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Contains all functions used to communicate to BOL about the inventory
    /// </summary>
    public class Inventory : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public Inventory(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }
    }
}
