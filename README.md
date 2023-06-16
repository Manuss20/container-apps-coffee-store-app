# container-apps-coffe-store-app
This repository was created to show users how to deploy a microservices-based sample application with Azure Container Apps using Dapr.


Create a Services projects:
dotnet new webapi -n coffeecapp.Services.Basket.API -o Basket.API
dotnet new webapi -n coffeecapp.Services.Catalog.API -o Catalog.API
dotnet new webapi -n coffeecapp.Services.Ordering.API -o Ordering.API
dotnet new webapi -n coffeecapp.Services.Store.API -o Store.API