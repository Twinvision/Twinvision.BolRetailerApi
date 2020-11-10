using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class PurchasableShippingLabel
    {
        public string TransporterCode { get; set; }
        public string LabelType { get; set; }
        public string MaxWeight { get; set; }
        public string MaxDimensions { get; set; }
        public decimal RetailerPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Discount { get; set; }
        public string ShippingLabelCode { get; set; }
    }
}
