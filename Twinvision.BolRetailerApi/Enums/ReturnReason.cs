using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// If a customer specifies the reason why the item is returned, one of these return reasons can be selected
    /// </summary>
    public enum ReturnReason
    {
        /// <summary>
        /// Incorrect information on website
        /// </summary>
        INCORRECT_PRODUCT_INFORMATION,
        /// <summary>
        /// Customer ordered wrong size
        /// </summary>
        WRONG_SIZE_ORDERED,
        /// <summary>
        /// Wrong item delivered to customer
        /// </summary>
        WRONG_ARTICLE_RECEIVED,
        /// <summary>
        /// Article was damaged when received
        /// </summary>
        ARTICLE_DAMAGED,
        /// <summary>
        /// Article is not working or is broken
        /// </summary>
        ARTICLE_BROKEN,
        /// <summary>
        /// Item not delivered in time
        /// </summary>
        ARTICLE_DELIVERY_TOO_LATE,
        /// <summary>
        /// Part(s) missing for the item
        /// </summary>
        ARTICLE_INCOMPLETE,
        /// <summary>
        /// Customer ordered wrong article
        /// </summary>
        WRONG_ARTICLE_ORDERED,
        /// <summary>
        /// If no other reason is applicable
        /// </summary>
        OTHER
    }
}
