using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    public class CustomerDetails
    {
        public string SalutationCode { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string HouseNumberExtended { get; set; }
        public string AddressSupplement { get; set; }
        public string ExtraAddressInformation { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string VatNumber { get; set; }
        public string ChamberOfCommerceNumber { get; set; }
        public string OrderReference { get; set; }
        public string DeliveryPhoneNumber { get; set; }
    }
}
