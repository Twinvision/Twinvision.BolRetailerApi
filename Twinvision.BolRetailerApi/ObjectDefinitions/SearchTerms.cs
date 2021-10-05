using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public enum EPeriod { DAY, WEEK, MONTH }
    public class SearchTerms
    {
        public string SearchTerm { get; set; }
        public string Type { get; set; }
        public float Total { get; set; }
        public Country[] Countries { get; set; }
        public Period[] Periods { get; set; }
        public RelatedSearchTerm RelatedSearchTerm { get; set; }
    }
}
