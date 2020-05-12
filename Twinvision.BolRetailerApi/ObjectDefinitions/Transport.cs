using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class Transport
    {
        /// <summary>Specify the transporter that will carry out the shipment.</summary>
        public string TransporterCode { get; set; }
        /// <summary>The track and trace code that is associated with this transport.</summary>
        public string TrackAndTrace { get; set; }

        public Transport(string transporterCode, string trackAndTrace)
        {
            TransporterCode = transporterCode;
            TrackAndTrace = trackAndTrace;
        }
    }
}
