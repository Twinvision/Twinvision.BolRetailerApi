using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Store
    {
        public string ProductTitle { get; set; }
        public Visible[] Visible { get; set; }
    }
}
