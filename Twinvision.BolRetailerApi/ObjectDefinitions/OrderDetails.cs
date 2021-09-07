using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class OrderDetails
    {
        public string OrderId { get; set; }
        public DateTime OrderPlacedDateTime { get; set; }
        public OrderCustomerDetails CustomerDetails { get; set; }
        public OrderItemDetails[] OrderItems { get; set; }
    }
}