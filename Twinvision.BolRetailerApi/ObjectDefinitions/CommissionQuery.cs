using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class CommissionQuery
    {
        public string Ean { get; set; }
        public string Condition { get; set; }
        public decimal Price { get; set; }

        public CommissionQuery(string ean, string condition, decimal price)
        {
            Ean = ean;
            Condition = condition;
            Price = price;
        }
    }
}