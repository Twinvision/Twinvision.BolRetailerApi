using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class OrderCustomerDetails
    {
        public ShipmentDetails ShipmentDetails { get; set; }
        public BillingDetails BillingDetails { get; set; }
    }
}
