using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class PostOffer
    {
        public string Ean { get; set; }
        public Condition Condition { get; set; }
        public string ReferenceCode { get; set; }
        public bool OnHoldByRetailer { get; set; }
        public string UnknownProductTitle { get; set; }
        public PricingContainer Pricing { get; set; }
        public Stock Stock { get; set; }
        public Fulfilment Fulfilment { get; set; }
    }
}
