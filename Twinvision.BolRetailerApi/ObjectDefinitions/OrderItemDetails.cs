using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class OrderItemDetails
    {
        public string OrderItemId { get; set; }
        public bool CancellationRequest { get; set; }
        public Fulfilment Fulfilment { get; set; }
        public Offer Offer { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int QuantityShipped { get; set; }
        public int QuantityCancelled { get; set; }
        public float UnitPrice { get; set; }
        public float Commission { get; set; }
        public List<AdditionalService> AdditionalServices { get; set; }
    }

}
