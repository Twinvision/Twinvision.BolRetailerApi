using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class DetailedTransport
    {
        public int TransportId { get; set; }
        public string TransporterCode { get; set; }
        public string TrackAndTrace { get; set; }
        public int ShippingLabelId { get; set; }
        public string ShippingLabelCode { get; set; }
    }
}
