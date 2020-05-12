using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class UpdatePriceContainer
    {
        public Pricing Pricing { get; set; }
        public UpdatePriceContainer(Pricing pricing)
        {
            Pricing = pricing;
        }
    }
}
