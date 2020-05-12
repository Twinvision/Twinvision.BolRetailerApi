using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class UpdateOffer
    {
        /// <summary>A user-defined reference that helps you identify this particular offer when receiving data from us. This element can optionally be left empty and has a maximum amount of 20 characters.</summary>
        public string ReferenceCode { get; set; }
        /// <summary>Indicates whether or not you want to put this offer for sale on the bol.com website. Defaults to false.</summary>
        public bool OnHoldByRetailer { get; set; }
        /// <summary>In case the item is not known to bol.com you can use this field to identify this particular product. Note: in case the product is known to bol.com, the unknown product title will not be stored.</summary>
        public string UnknownProductTitle { get; set; }
        /// <summary>Offer fulfilment specification.</summary>
        public Fulfilment Fulfilment { get; set; }

        public UpdateOffer(Fulfilment fulfilment)
        {
            Fulfilment = fulfilment;
        }
    }
}
