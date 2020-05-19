using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Score
    {
        public bool Conforms { get; set; }
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public float Value { get; set; }
        public float DistanceToNorm { get; set; }
    }
}
