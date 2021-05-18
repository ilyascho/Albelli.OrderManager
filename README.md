# Test Assignment - Ilyas Haciomeroglu #
Test assignment project

<!-- ABOUT THE PROJECT -->
## About The Project

The aim of this project is to create a .NET Web API that accepts an order, stores the order and responds with a RequiredBinWidth.


### Main Points:
* Microsoft.EntityFrameworkCore.InMemory is used as a general purpose database
* CQRS pattern is used with MediatR
* AutoMapper for ojbect-to-object mapping
* xUnit and Moq for unit testing
* Virtual CalculateBinWidth method porvides polymorphism
* Builder pattern (OrderBuilder) is used to create an Order


#### TO RUN THE APPLICATION

- [x] Set "Albelli.OrderManager.API" as Startup Project

- [x] Run the application

- [x] Use Swagger endpoints

Sample POST request body
```json
{
  "orderProducts": [
    {
      "productType": "PhotoBook",
      "quantity": 1
    },
    {
      "productType": "Mug",
      "quantity": 9
    }
  ]
}
```
