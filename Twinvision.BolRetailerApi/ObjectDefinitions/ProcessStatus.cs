using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class ProcessStatus
    {
        public string Id { get; set; }
        public string EntityId { get; set; }
        public string EventType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreateTimestamp { get; set; }
        public Link[] Links { get; set; }
    }
}