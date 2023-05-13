# Table of Contents
- [VehiclesAPI](#vehiclesapi)
  - [Usage](#usage)
  - [Getting Started](#getting-started)
  - [Endpoints](#endpoints)
    - [Automobile enpoints:](#automobile-enpoints)
    - [Motorcycle enpoints:](#motorcycle-enpoints)
    - [Boat enpoints:](#boat-enpoints)
  - [Data Model](#data-model)
    - [Automobile model:](#automobile-model)
    - [Motorcycle model:](#motorcycle-model)
    - [Boat model:](#boat-model)


# VehiclesAPI

VehiclesAPI is a simple **ASP.NET Core Web API** that provides endpoints for managing a list of automobiles. It allows you to perform basic **CRUD** (Create, Read, Update, Delete) operations on a list of vehicles, and stores the data in memory.

## Usage

To use the **VehiclesAPI**, you can clone the repository and run the application **locally** using Visual Studio or the .NET CLI. Once the application is running, you can make **HTTP** requests to the available endpoints using a tool like Postman or cURL.

## Getting Started

To use the API, simply make **HTTP** requests to the appropriate endpoint. For example, to retrieve a list of all automobiles, make a **`GET`** request to the following URL:
`http://localhost:5164/automobile/list`.

For more information about how to use the API, please refer to the documentation in `http://localhost:5164/swagger/index.html`

## Endpoints

The following endpoints are available:

### Automobile enpoints:

| **Endpoin**t                  | **Method**   | **Description**                                       |
|-------------------------------|--------------|-------------------------------------------------------|
| `/automobile/list`            | **`GET`**    | Returns a list of all automobiles.                    |
| `/automobile/{id}`            | **`GET`**    | Returns a single automobile with the specified id.    |
| `/automobile/save`            | **`POST`**   | Saves a new automobile to the list.                   |
| `/automobile/update/{id}`     | **`PUT`**    | Updates an existing automobile with the specified id. |
| `/automobile/delete/{id}`     | **`DELETE`** | Deletes an existing automobile with the specified id. |


### Motorcycle enpoints:

| **Endpoin**t                  | **Method**   | **Description**                                       |
|-------------------------------|--------------|-------------------------------------------------------|
| `/motorcycle/list`            | **`GET`**    | Returns a list of all motorcycles.                    |
| `/motorcycle/{id}`            | **`GET`**    | Returns a single motorcycle with the specified id.    |
| `/motorcycle/save`            | **`POST`**   | Saves a new motorcycle to the list.                   |
| `/motorcycle/update/{id}`     | **`PUT`**    | Updates an existing motorcycle with the specified id. |
| `/motorcycle/delete/{id}`     | **`DELETE`** | Deletes an existing motorcycle with the specified id. |


### Boat enpoints:

| **Endpoin**t                  | **Method**   | **Description**                                       |
|-------------------------------|--------------|-------------------------------------------------------|
| `/boat/list`                  | **`GET`**    | Returns a list of all boats.                          |
| `/boat/{id}`                  | **`GET`**    | Returns a single boat with the specified id.          |
| `/boat/save`                  | **`POST`**   | Saves a new boat to the list.                         |
| `/boat/update/{id}`           | **`PUT`**    | Updates an existing boat with the specified id.       |
| `/boat/delete/{id}`           | **`DELETE`** | Deletes an existing boat with the specified id.       |

## Data Model

### Automobile model:

The `Automobile` model represents an automobile, and has the following properties:

| **Property**       | **Type**   | **Description**                          |
|--------------------|------------|------------------------------------------|
| **`Id`**           | `string`   | Unique identifier for the automobile     |
| **`Make`**         | `string`   | Make of the automobile                   |
| **`Model`**        | `string`   | Model of the automobile                  |
| **`Year`**         | `string`   | Year of the automobile                   |
| **`BodyType`**     | `string`   | Body type of the automobile              |
| **`EngineSize`**   | `string`   | Engine size of the automobile            |

### Motorcycle model:

The `Motorcycle` model represents an motorcycle, and has the following properties:

| **Property**       | **Type**   | **Description**                          |
|--------------------|------------|------------------------------------------|
| **`Id`**           | `string`   | Unique identifier for the motorcycle     |
| **`Make`**         | `string`   | Make of the motorcycle                   |
| **`Model`**        | `string`   | Model of the motorcycle                  |
| **`Year`**         | `string`   | Year of the motorcycle                   |
| **`CylinderCapacity`**     | `string`   | Cylinder capacity of the motorcycle              |
| **`Color`**   | `string`   | Color of the motorcycle            |

### Boat model:

The `Boat` model represents a boat, and has the following properties:

| **Property**       | **Type**   | **Description**                          |
|--------------------|------------|------------------------------------------|
| **`Id`**           | `string`   | Unique identifier for the boat           |
| **`Name`**         | `string`   | Name of the boat                         |
| **`Type`**         | `string`   | Type of the boat                         |
| **`Size`**         | `string`   | Size of the boat                         |
| **`Length`**       | `string`   | Length of the boat                       |
| **`Capacity`**     | `string`   | Capacity of the boat                     |
