# BolRetailerApi
A C# class library of all the endpoints for the [BOL API](https://api.bol.com/retailer/public)

This project aims at creating a library which forces you to fill in all required information.
Meaning we require objects to be passed through functions, which can only be created using constructors with the minimally required information.



Some examples: 

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

Get all open orders on page 1:
```cs
var bolApiCaller = new BolApiCaller(testClientId, testClientSecret);
var response = await bolApiCaller.Orders.GetOpenOrders(1, FulFilmentType.FBR);
```

For more examples look at the Test project, which contains an implementation for every supported function.
