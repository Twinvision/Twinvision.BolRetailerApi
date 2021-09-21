using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class ProcessingResultContainer
    {
        public int Quantity { get; set; }
        public string ProcessingResult { get; set; }
        public string HandlingResult { get; set; }
        public string ProcessingDateTime { get; set; }
    }
}
