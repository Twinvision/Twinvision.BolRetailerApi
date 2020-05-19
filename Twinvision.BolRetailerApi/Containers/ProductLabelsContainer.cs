using System;
using System.Collections.Generic;
using System.Text;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi.Containers
{
    public enum PrinterFormat { AVERY_J8159, AVERY_J8160, AVERY_3474, DYMO_99012, BROTHER_DK11208D, ZEBRA_Z_PERFORM_1000T }

    public class ProductLabelsContainer
    {
        public string Format { get; set; }
        public ProductLabel[] ProductLabels { get; set; } 

        public ProductLabelsContainer(ProductLabel[] productLabels, PrinterFormat format = PrinterFormat.AVERY_J8159)
        {
            Format = format.ToString();
            ProductLabels = productLabels;
        }
    }
}
