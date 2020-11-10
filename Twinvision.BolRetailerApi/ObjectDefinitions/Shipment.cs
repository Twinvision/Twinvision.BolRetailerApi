using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string ShipmentReference { get; set; }
        public ShipmentItem[] ShipmentItems { get; set; }
        public TransportIdentifier Transport { get; set; }
    }
}