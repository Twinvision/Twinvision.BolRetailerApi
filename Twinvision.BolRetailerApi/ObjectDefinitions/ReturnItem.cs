using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class ReturnItem
    {
        public int RmaId { get; set; }
        public string OrderId { get; set; }
        public string Ean { get; set; }
        public int ExpectedQuantity { get; set; }
        public ReturnReason ReturnReason { get; set; }
        public bool Handled { get; set; }
        public string ProcessingResult { get; set; }
    }
}
