# BolRetailerApi
A C# mapping of all the endpoints for the BOL API

This 

```cs

var bolApiCaller = new BolApiCaller(testClientId, testClientSecret);
var response = await bolApiCaller.Offers.GetOfferExportFile();
```
