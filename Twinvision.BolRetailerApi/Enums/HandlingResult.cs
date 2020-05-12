using System;
using System.Collections.Generic;
using System.Text;

namespace Twinvision.BolRetailerApi
{
    /// <summary>
    /// Set of results used when handling a return
    /// </summary>
    public enum HandlingResult 
    {
        /// <summary>
        /// Return is received as expected and approved.
        /// </summary>
        RETURN_RECEIVED,
        /// <summary>
        /// In consultation with the customer, the product will be exchanged or replaced.
        /// </summary>
        EXCHANGE_PRODUCT,
        /// <summary>
        /// Return did not met the expectation/condition.
        /// </summary>
        RETURN_DOES_NOT_MEET_CONDITIONS,
        /// <summary>
        /// You will take the lead in repairing the product for the customer.
        /// </summary>
        REPAIR_PRODUCT,
        /// <summary>
        /// Customer is allowed to keep the product.
        /// </summary>
        CUSTOMER_KEEPS_PRODUCT_PAID,
        /// <summary>
        /// In consultation with the customer, the return is still approved after an initial rejection. With this handling result, you can still refund the customer.
        /// </summary>
        STILL_APPROVED,
        /// <summary>
        /// Customer is allowed to keep the product with no costs.
        /// </summary>
        CUSTOMER_KEEPS_PRODUCT_FREE_OF_CHARGE,
        /// <summary>
        /// Somewhere on it’s way back to the seller the return item was lost
        /// </summary>
        RETURN_ITEM_LOST,
        /// <summary>
        /// The time between registering a return and sending it back took more than 21 days. The return is therefore cancelled.
        /// </summary>
        EXPIRED,
        /// <summary>
        /// Feedback with more quantity than ordered was supplied.
        /// </summary>
        EXCESSIVE_RETURN,
        /// <summary>
        /// The return was reported lost but was still received.
        /// </summary>
        STILL_RECEIVED,
        /// <summary>
        /// The customer decided to cancel his/her return
        /// </summary>
        CANCELLED_BY_CUSTOMER,
        /// <summary>
        /// The transporter failed to create a shipping label. The return is therefore cancelled.
        /// </summary>
        FAILED_TO_CREATE_SHIPPING_LABEL
    };
}
