using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    /// <summary>
    /// Ship a single order item within a customer order by providing shipping information. 
    /// In case you purchased a shipping label you can add the shippingLabelCode to this message. 
    /// In that case the transport element must be left empty. 
    /// If you ship the item(s) using your own transporter method you must omit the shippingLabelCode entirely.
    /// </summary>
    public class ShippingInfo
    {
        /// <summary>Used for administration purposes.</summary>
        public string ShipmentReference { get; set; }
        /// <summary>Specifies shipping label to be used for this shipment. Can be retrieved through the shipping label endpoint.</summary>
        public string ShippingLabelCode { get; set; }
        /// <summary>TransportInstruction</summary>
        public Transport Transport { get; set; }
    }
}
