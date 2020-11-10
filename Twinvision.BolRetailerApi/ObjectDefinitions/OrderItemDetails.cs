using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class OrderItemDetails
    {
        public string OrderItemId { get; set; }
        public string OfferReference { get; set; }
        public string Ean { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public float OfferPrice { get; set; }
        public string OfferId { get; set; }
        public float TransactionFee { get; set; }
        public string LatestDeliveryDate { get; set; }
        public string ExpiryDate { get; set; }
        public string OfferCondition { get; set; }
        public bool CancelRequest { get; set; }
        public string FulfilmentMethod { get; set; }
        public AdditionalService[] AdditionalServices { get; set; }
    }

}
