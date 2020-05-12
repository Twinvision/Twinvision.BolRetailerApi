using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    public class StatusResponse
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