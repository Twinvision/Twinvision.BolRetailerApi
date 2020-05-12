using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.Containers
{
    class InboundShipmentContainer
    {
        public string Reference { get; set; }
        public Timeslot TimeSlot { get; set; }
        public FbbTransporter FbbTransporter { get; set; }
        public bool LabellingService { get; set; }
        public Product[] Products { get; set; }
    }
}
