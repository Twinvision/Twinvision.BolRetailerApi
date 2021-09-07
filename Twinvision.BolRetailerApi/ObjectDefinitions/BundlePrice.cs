using System;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class BundlePrice
    {
        /// <summary></summary>
        public int Quantity { get; set; }
        /// <summary></summary>
        public decimal UnitPrice { get; set; }

        public BundlePrice(int quantity, decimal price)
        {
            Quantity = quantity;
            UnitPrice = price;
        }
    }
}
