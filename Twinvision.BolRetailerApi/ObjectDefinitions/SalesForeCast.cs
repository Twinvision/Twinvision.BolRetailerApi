using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class SalesForeCast
    {
        public string Name { get; set; }
        public string Decimal { get; set; }
        public Total Total { get; set; }
        public Country[] Countries { get; set; }
        public ForecastPeriod Periods { get; set; }
    }
}
