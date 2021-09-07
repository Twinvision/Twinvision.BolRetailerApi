using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class CreateOffer
    {
        /// <summary>The EAN number associated with this product. Note: in case an ISBN is provided, the ISBN will be replaced with the actual EAN belonging to this ISBN.</summary>
        public string Ean { get; set; }
        /// <summary>Condition of the offer.</summary>
        public Condition Condition { get; set; }
        /// <summary>A user-defined reference that helps you identify this particular offer when receiving data from us. This element can optionally be left empty and has a maximum amount of 20 characters.</summary>
        public string Reference { get; set; }
        /// <summary>Indicates whether or not you want to put this offer for sale on the bol.com website. Defaults to false.</summary>
        public bool OnHoldByRetailer { get; set; }
        /// <summary>In case the item is not known to bol.com you can use this field to identify this particular product. Note: in case the product is known to bol.com, the unknown product title will not be stored.</summary>
        public string UnknownProductTitle { get; set; }
        /// <summary>Pricings for the offer.</summary>
        public PricingContainer Pricing { get; set; }
        /// <summary>Stocks for the offer</summary>
        public Stock Stock { get; set; }
        /// <summary>Fulfilment specifications for the offer.</summary>
        public SmallFulfilment Fulfilment { get; set; }

        public CreateOffer(string ean, Condition condition, PricingContainer pricing, Stock stock, SmallFulfilment fulfilment)
        {
            Ean = ean;
            Condition = condition;
            Pricing = pricing;
            Stock = stock;
            Fulfilment = fulfilment;
        }
    }
}
