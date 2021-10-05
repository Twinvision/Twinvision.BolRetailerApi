using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class ForecastPeriod
    {
        public int WeeksAhead { get; set; }
        public Total Total { get; set; }
        public Country[] Countries { get; set; }
    }
}
