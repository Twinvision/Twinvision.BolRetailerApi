using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class NotificationSubscription
    {
        public int Id { get; set; }
        public string[] Resources { get; set; }
        public string Url { get; set; }
    }
}
