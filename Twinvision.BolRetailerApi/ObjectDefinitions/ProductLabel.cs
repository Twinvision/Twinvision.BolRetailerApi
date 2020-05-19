using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class ProductLabel
    {
        public string Ean { get; set; }
        public int Quantity { get; set; }

        public ProductLabel(string ean, int quantity)
        {
            Ean = ean;
            Quantity = quantity;
        }
    }
}
