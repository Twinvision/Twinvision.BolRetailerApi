using System;
using System.Collections.Generic;
using System.Text;
using Twinvision.BolRetailerApi;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Return
    {
        public string ReturnId { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FulfilmentMethod { get; set; }
        public List<ReturnItem> ReturnItems { get; set; }
    }
}
