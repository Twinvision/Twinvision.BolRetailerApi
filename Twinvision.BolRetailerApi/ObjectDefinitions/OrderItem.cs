using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class OrderItem
    {
        public string OrderItemId { get; set; }
        public string Ean { get; set; }
        public bool CancelRequest { get; set; }
        public int Quantity { get; set; }
    }
}
