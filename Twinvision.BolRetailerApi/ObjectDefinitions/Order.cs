using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Order
    {
        public string OrderId { get; set; }
        public DateTime DateTimeOrderPlaced { get; set; }
        public OrderItem[] OrderItems { get; set; }
    }
}
