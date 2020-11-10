using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Reduction
    {
        public float MaximumPrice { get; set; }
        public float CostReduction { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
