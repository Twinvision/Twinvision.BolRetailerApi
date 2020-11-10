using System;
using System.Collections.Generic;
using System.Text;
using Twinvision.BolRetailerApi.ObjectDefinitions;

namespace Twinvision.BolRetailerApi
{
    public class ApiCallException : Exception
    {
        public override string Message
        {
            get
            {
                var message = Status + " " + Detail;
                if (Violations != null)
                {
                    foreach (var violation in Violations)
                    {
                        message += " Name: " + violation.Name + " Reason: " + violation.Reason + " ";
                    }
                }
                return message;
            }
        }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }
        public string Host { get; set; }
        public string Instance { get; set; }
        public Violation[] Violations { get; set; }
    }
}