using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class RetailPrice
    {
        /// <summary></summary>
        public string Country { get; set; }
        /// <summary></summary>
        public decimal Price { get; set; }

        public RetailPrice(string country, decimal price)
        {
            Country = country;
            Price = price;
        }
    }
}