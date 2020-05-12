using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class BolRetailerApiException : Exception
    {
        public BolRetailerApiException(string message) : base(message)
        {

        }
    }
}
