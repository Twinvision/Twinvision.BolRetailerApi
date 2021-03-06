﻿using System;
using System.Collections.Generic;
using System.Text;
using Twinvision.BolRetailerApi;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Return
    {
        public int RmaId { get; set; }
        public string OrderId { get; set; }
        public string Ean { get; set; }
        public int Quantity { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string ReturnReason { get; set; }
        public string ReturnReasonComments { get; set; }
        public string FulfilmentMethod { get; set; }
        public bool Handled { get; set; }
        public string HandlingResult { get; set; }
        public string ProcessingResult { get; set; }
        public DateTime ProcessingDateTime { get; set; }
    }
}
