using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class CommissionQuery
    {
        public string Ean { get; set; }
        public string Condition { get; set; }
        public decimal UnitPrice { get; set; }

        public CommissionQuery(string ean, string condition, decimal unitPrice)
        {
            Ean = ean;
            Condition = condition;
            UnitPrice = unitPrice;
        }
    }
}