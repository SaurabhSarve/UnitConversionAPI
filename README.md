# Unit Conversion API

A RESTful ASP.NET Core Web API for converting values between different units of measurement.

The application follows Clean Architecture principles and is designed to be maintainable, scalable, and easy to extend with additional conversion categories in the future.

---

## Features

* Convert values between different units
* Support for multiple conversion categories
* Clean Architecture implementation
* Dependency Injection
* FluentValidation for request validation
* Global Exception Handling Middleware
* Serilog logging
* Unit Tests using xUnit
* Health Check Endpoint

---

## Supported Conversion Categories

### Length

* Meter
* Kilometer
* Centimeter
* Foot
* Inch
* Mile

### Weight

* Kilogram
* Gram
* Pound
* Ounce

### Temperature

* Celsius
* Fahrenheit
* Kelvin

---

## Project Structure

```text
UnitConversionAPI
│
├── src
│   ├── UnitConversion.API
│   ├── UnitConversion.Application
│   ├── UnitConversion.Domain
│   └── UnitConversion.Infrastructure
│
├── tests
│   └── UnitConversion.Tests
│
└── README.md
```

---

## Architecture

### API Layer

Responsible for:

* Controllers
* Middleware
* Request handling
* Dependency Injection configuration

### Application Layer

Responsible for:

* DTOs
* Interfaces
* Services
* Validation
* Business contracts

### Domain Layer

Responsible for:

* Entities
* Enums
* Constants
* Core business concepts

### Infrastructure Layer

Responsible for:

* Unit conversion implementations
* External service integrations
* Data access implementations (future)

---

## Design Decisions

### Strategy Pattern

Each conversion category is implemented using a separate converter:

* LengthConverter
* WeightConverter
* TemperatureConverter

This allows new categories to be added without modifying existing conversion logic.

### Dependency Injection

All services and converters are registered through ASP.NET Core Dependency Injection to improve maintainability and testability.

### Validation

FluentValidation is used to validate incoming requests before business logic execution.

### Error Handling

A global exception middleware ensures consistent API responses and centralized exception management.

---

## API Endpoints

### Convert Units

**POST**

```http
/api/conversions
```

Request:

```json
{
  "value": 100,
  "fromUnit": "meter",
  "toUnit": "foot"
}
```

Response:

```json
{
  "originalValue": 100,
  "fromUnit": "meter",
  "toUnit": "foot",
  "convertedValue": 328.084
}
```

---

### Get Supported Units

**GET**

```http
/api/conversions/units
```

Sample Response:

```json
{
  "length": [
    "meter",
    "kilometer",
    "centimeter",
    "foot",
    "inch",
    "mile"
  ],
  "weight": [
    "kilogram",
    "gram",
    "pound",
    "ounce"
  ],
  "temperature": [
    "celsius",
    "fahrenheit",
    "kelvin"
  ]
}
```

---

### Health Check

**GET**

```http
/api/health
```

Response:

```json
{
  "status": "Healthy"
}
```

---

## Running Locally

### Prerequisites

* .NET 8 SDK

Verify installation:

```bash
dotnet --version
```

---

### Clone Repository

```bash
git clone <repository-url>
```

Navigate to project:

```bash
cd UnitConversionAPI
```

---

### Restore Dependencies

```bash
dotnet restore
```

---

### Build Project

```bash
dotnet build
```

---

### Run Application

```bash
dotnet run --project src/UnitConversion.API
```

---

### Test API

Health Endpoint:

```http
GET https://localhost:<port>/api/health
```

---

## Running Tests

Execute all tests:

```bash
dotnet test
```

---

## Future Enhancements

The current solution uses hardcoded unit definitions as required by the assessment.

Potential future improvements:

* Database-backed unit definitions
* Dynamic unit management
* API versioning
* Caching
* Event-driven architecture
* Azure deployment
* Additional conversion categories

  * Area
  * Volume
  * Speed
  * Pressure
  * Energy
* Natural language conversion support using AI

---

## Technologies Used

* .NET 8
* ASP.NET Core Web API
* C#
* FluentValidation
* Serilog
* xUnit
* FluentAssertions
* Clean Architecture
* Dependency Injection

---
