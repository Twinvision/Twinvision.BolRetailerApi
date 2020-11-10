using System;
using System.Collections.Generic;
using System.Text;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi
{
    public class UpdatePriceContainer
    {
        public PricingContainer Pricing { get; set; }
        public UpdatePriceContainer(PricingContainer pricing)
        {
            Pricing = pricing;
        }
    }
}
