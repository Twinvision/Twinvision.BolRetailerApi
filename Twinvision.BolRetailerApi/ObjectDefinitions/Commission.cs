﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Commission
    {
        public string Ean { get; set; }
        public string Condition { get; set; }
        public float UnitPrice { get; set; }
        public float FixedAmount { get; set; }
        public int Percentage { get; set; }
        public float TotalCost { get; set; }
        public float TotalCostWithoutReduction { get; set; }
        public Reduction[] Reductions { get; set; }
    }
}

