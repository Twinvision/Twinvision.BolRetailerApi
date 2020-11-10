using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Offer
    {
        public string OfferId { get; set; }
        public string Ean { get; set; }
        public string ReferenceCode { get; set; }
        public bool OnHoldByRetailer { get; set; }
        public string UnknownProductTitle { get; set; }
        public PricingContainer Pricing { get; set; }
        public Stock Stock { get; set; }
        public Fulfilment Fulfilment { get; set; }
        public Store Store { get; set; }
        public Condition Condition { get; set; }
        public NotPublishableReason[] NotPublishableReasons { get; set; }
    }
}
