using System;

namespace Twinvision.BolRetailerApi
{
    public class BundlePrice
    {
        /// <summary></summary>
        public int Quantity { get; set; }
        /// <summary></summary>
        public decimal Price { get; set; }

        public BundlePrice(int quantity, decimal price)
        {
            Quantity = quantity;
            Price = price;
        }
    }
}
