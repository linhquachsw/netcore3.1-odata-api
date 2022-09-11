# ODataHeroes - ASP.NET Core OData Boilerplate

ODataHeroes is a boilerplate solution, built to demonstrate OData API implementation in an ASP.NET Core (.NET Core 3.1) API

# What is OData?

OData stands for Open Data. It is an ISO/IEC approved, OASIS standard that defines a set of best practices for building and consuming RESTful APIs. It can help enhance an API to have extensive capabilities by itself, while we don't need to worry much about the data processing and response transformations as a whole and instead concentrate only on building the business logic for the API. OData adds one layer over the API treating the endpoint itself as a resource and adds the transformation capabilities via the URL.

One can integrate the prowess of OData into an ASP.NET Core API by installing the OData nuget available for .NET Core and get started.

# Technoligies

1. ASP.NET Core (.NET Core 3.1)
2. Entity Framework Core (EF Core 5)
3. OData Library for ASP.NET Core (8.0.10)
4. AspNetCore Mvc Versioning (5.0.0)
5. Swagger (Swashbuckle AspNetCore 6.4)

# About the Boilerplate

This boilerplate is a perfect starter for developers looking to implement OData. The solution offers the following:

1. Onion Architecture with defined layers for API, Persistence, Contracts and Migrations
2. Implemented code for UnitOfWork with Repository
3. Seperated Controllers for API and OData
4. Apply API versioning
5. Preconfigured Entity Framework Core migrations

# Getting Started

To get started, follow the below steps:

1. Install .NET SDK
2. Install Microsoft Sql Management Studio, Postman
3. Clone the Solution into your Local Directory
4. Naviage to the Cloned directory and run Script create data in database folder (open MSMS and run script)
5. Change ConnectionStrings with Server Local
6. Run the solution

# Testing the Solution

Once the solution is running, open Swagger and basic testing. Besides you also try the below URLs to see OData in action

Postman Collections API-OData-Demo: https://www.postman.com/collections/c3d843a910b88daf5591
