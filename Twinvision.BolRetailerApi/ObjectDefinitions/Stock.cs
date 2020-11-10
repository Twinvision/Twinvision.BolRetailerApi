namespace Twinvision.BolRetailerApi.ObjectDefinitions
{
    public class Stock
    {
        /// <summary>
        /// The amount of stock available for the specified product present in the retailers warehouse. 
        /// Note: this should not be the FBB stock! 
        /// Defaults to 0.
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Configures whether the retailer manages the stock levels or that bol.com should calculate the corrected stock based on actual open orders.
        /// In case the configuration is set to 'false', all open orders are used to calculate the corrected stock. 
        /// In case the configuration is set to 'true', only orders that are placed after the last offer update are taken into account. 
        /// Default is set to 'false'.
        /// </summary>
        public bool ManagedByRetailer { get; set; }

        public Stock(int amount, bool managedByRetailer)
        {
            Amount = amount;
            ManagedByRetailer = managedByRetailer;
        }
    }
}
