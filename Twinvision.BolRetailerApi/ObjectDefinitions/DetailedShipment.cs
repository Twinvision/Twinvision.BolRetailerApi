using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class DetailedShipment
    {
        public int ShipmentId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string ShipmentReference { get; set; }
        public ShipmentItem[] ShipmentItems { get; set; }
        public Transport Transport { get; set; }
        public CustomerDetails CustomerDetails { get; set; }
        public BillingDetails BillingDetails { get; set; }
    }
}
