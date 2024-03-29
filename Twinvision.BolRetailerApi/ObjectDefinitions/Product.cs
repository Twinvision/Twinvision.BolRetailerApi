﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Product
    {
        public string Ean { get; set; }
        public string Title { get; set; }
        public string Bsku { get; set; }
        public int AnnouncedQuantity { get; set; }
        public int ReceivedQuantity { get; set; }
        public string State { get; set; }
    }
}
