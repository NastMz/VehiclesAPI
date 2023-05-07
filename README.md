# Table of Contents
- [VehiclesAPI](#vehiclesapi)
  - [Usage](#usage)
  - [Getting Started](#getting-started)
  - [Endpoints](#endpoints)
    - [Automobile enpoints:](#automobile-enpoints)
  - [Data Model](#data-model)
    - [Automobile model:](#automobile-model)


# VehiclesAPI

VehiclesAPI is a simple **ASP.NET Core Web API** that provides endpoints for managing a list of automobiles. It allows you to perform basic **CRUD** (Create, Read, Update, Delete) operations on a list of vehicles, and stores the data in memory.

## Usage

To use the **VehiclesAPI**, you can clone the repository and run the application locally using Visual Studio or the .NET CLI. Once the application is running, you can make **HTTP** requests to the available endpoints using a tool like Postman or cURL.

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
| `/automobile/{id}`        | **`GET`**    | Returns a single automobile with the specified id.    |
| `/automobile/save`            | **`POST`**   | Saves a new automobile to the list.                   |
| `/automobile/update/{id}`     | **`PUT`**    | Updates an existing automobile with the specified id. |
| `/automobile/delete/{id}`     | **`DELETE`** | Deletes an existing automobile with the specified id. |

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
