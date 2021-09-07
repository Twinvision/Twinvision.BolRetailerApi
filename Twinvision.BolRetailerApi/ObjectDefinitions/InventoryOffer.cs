using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class InventoryOffer
    {
        public string Ean { get; set; }
        public string Bsku { get; set; }
        public int GradedStock { get; set; }
        public int RegularStock { get; set; }
        public string Title { get; set; }
    }
}
