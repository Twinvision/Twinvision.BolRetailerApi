using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class CreateNotificationSubscription
    {
        public string[] Resources { get; set; }
        public string Url { get; set; }

        public CreateNotificationSubscription(string[] resources, string url)
        {
            Resources = resources;
            Url = url;
        }
    }
}
