using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class HandleReturnContainer
    {
        public string HandlingResult { get; set; }
        public int QuantityReturned { get; set; }

        public HandleReturnContainer(int quantityReturned, HandlingResult handlingResult)
        {
            QuantityReturned = quantityReturned;
            HandlingResult = handlingResult.ToString();
        }
    }
}
