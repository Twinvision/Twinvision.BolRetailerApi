using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class OrderItemCancellation
    {
        public string OrderItemId { get; set; }
        public string ReasonCode { get; set; }
    }
}
