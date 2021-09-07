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
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// This class is the core of the bolapi project.
    /// It is used to call api endpoints through statically typed code.
    /// Each property on this class is used as a seperation of logic to easily find what api calls you are looking for.
    /// </summary>
    public class BolApiCaller
    {
        public Commisions Commissions { get; }
        public Insights Insights { get; }
        public Inventory Inventory { get; }
        public Invoices Invoices { get; }
        public Offers Offers { get; }
        public Orders Orders { get; }
        public Pricing Pricing { get; }
        public ProcessStatuses ProcessStatus { get; }
        public Returns Returns { get; }
        public Shipments Shipments { get; }
        public ShippingLabels ShippingLabels { get; }
        public Subscriptions Subscriptions { get; }
        public Transports Transports { get; }

        /// <summary>
        /// Constructor used to create an instance of the BolApiCaller
        /// </summary>
        /// <param name="clientId">The api clientId required for authorization, requestable from bol itself.</param>
        /// <param name="clientSecret">The api clientSecret required for authorization, requestable from bol itself.</param>
        /// <param name="useDemoEnvironment">If set to true all calls will be directed at bol's demo test environment, this should never be used unless you want to invoke calls without processing them.</param>
        public BolApiCaller(string clientId, string clientSecret, bool useDemoEnvironment = false)
        {
            Task.Run(() => BolApiHttpRequestHandler.Initialize(clientId, clientSecret, useDemoEnvironment)).Wait();

            Commissions = new Commisions(this);
            Insights = new Insights(this);
            Inventory = new Inventory(this);
            Invoices = new Invoices(this);
            Offers = new Offers(this);
            Orders = new Orders(this);
            Pricing = new Pricing(this);
            ProcessStatus = new ProcessStatuses(this);
            Returns = new Returns(this);
            Shipments = new Shipments(this);
            ShippingLabels = new ShippingLabels(this);
            Subscriptions = new Subscriptions(this);
            Transports = new Transports(this);
        }
    }
}
