using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class Inbound
    {
        public long Id { get; set; }
        public string Reference { get; set; }
        public DateTime CreationDate { get; set; }
        public string State { get; set; }
        public bool LabellingService { get; set; }
        public long AnnouncedBSKUs { get; set; }
        public long AnnouncedQuantity { get; set; }
        public long ReceivedBSKUs { get; set; }
        public long ReceivedQuantity { get; set; }
        public Timeslot TimeSlot { get; set; }
        public Product[] Products { get; set; }
        public StateTransition[] StateTransitions { get; set; }
        public FbbTransporter FbbTransporter { get; set; }
    }
}
