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
        public DateTime? LatestDeliveryDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime? ExactDeliveryDate { get; set; }
        public string OfferCondition { get; set; }
        public bool CancelRequest { get; set; }
        public string FulfilmentMethod { get; set; }
        public AdditionalService[] AdditionalServices { get; set; }
    }

}
