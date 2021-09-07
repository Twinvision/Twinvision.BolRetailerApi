using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class SmallFulfilment
    {
        /// <summary>Specifies whether this shipment has been fulfilled by the retailer (FBR) or fulfilled by bol.com (FBB). Defaults to FBR.</summary>
        public string Method { get; set; }
        /// <summary>The delivery promise that applies to this offer. Valid codes: ("24uurs-23","24uurs-22","24uurs-21","24uurs-20","24uurs-19","24uurs-18","24uurs-17","24uurs-16","24uurs-15","24uurs-14","24uurs-13","24uurs-12","1-2d","2-3d","3-5d","4-8d","1-8d")</summary>
        public string DeliveryCode { get; set; }

        public SmallFulfilment(FulFilmentMethod fulFilmentMethod = FulFilmentMethod.FBR)
        {
            Method = fulFilmentMethod.ToString();
        }
    }
}
