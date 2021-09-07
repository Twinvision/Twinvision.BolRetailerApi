using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Order
    {
        public string OrderId { get; set; }
        public bool PickupPoint { get; set; }
        public DateTime OrderPlacedDateTime { get; set; }
        public ShipmentDetails ShipmentDetails { get; set; }
        public BillingDetails BillingDetails { get; set; }
        public OrderItem[] OrderItems { get; set; }
    }
}
