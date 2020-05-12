using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class UpdateStockContainer
    {
        public int Amount { get; set; }
        public bool ManagedByRetailer { get; set; }
    }
}
