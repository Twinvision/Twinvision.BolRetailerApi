

# BolRetailerApi
A C# .NET Standard class library of all the endpoints for the [BOL RETAILER API](https://api.bol.com/retailer/public)
[![Build Status](https://dev.azure.com/TwinvisionSoftware/BolRetailerApi/_apis/build/status/Twinvision.Twinvision.BolRetailerApi?branchName=master)](https://dev.azure.com/TwinvisionSoftware/BolRetailerApi/_build/latest?definitionId=13&branchName=master)

This project aims at creating a library which forces you to fill in all required information to perform each request.
It then handles all the more detailed HttpClient configurations, and will deal with deserialisation.
The library also handles recreation of timed out authentications so you don't have to bother.

# Supported:
 - Commissions
 - Invoicing
 - Offers
 - Orders
 - ProcessStatus
 - Returns
 - Shipment
 - ShipmentLabels
 - Subscriptions (Beta)
 - Transport
 - Inbounds
 - Insights
 - Inventory
 - Reductions

# Examples:

Get all open orders on page 1:
```cs
var bolApiCaller = new BolApiCaller(testClientId, testClientSecret);
var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentType.FBR);
```

Fetching all offers as a csv string from BOL:
```cs
var bolApiCaller = new BolApiCaller(testClientId, testClientSecret);
var response = await bolApiCaller.Offers.GetOfferExportFile();
```

Updating an offer price:
```cs
var bolApiCaller = new BolApiCaller(testClientId, testClientSecret);
var bundlePrices = new List<BundlePrice>()
{
    new BundlePrice(1, 6.55m)
};
var pricing = new Pricing(bundlePrices);
var result = await bolApiCaller.Offers.UpdateOfferPrice(someOffer.OfferId.ToString(), pricing);
```

# Tests

For more examples look at the Test project, which contains an implementation for every supported function.

P.S.
If you want to run all the unit tests yourself you will have to use your own ClientId and ClientSecret.
For more information about this check the "CheckCredentialsSet" TestMethod in the "ASetup" TestClass
