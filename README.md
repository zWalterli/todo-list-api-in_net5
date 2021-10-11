# VUTTR
Very Useful Tools to Remember

Simple repository to manage tools with their respective names, links, descriptions and tags.

The graphical interface of this project is [here](https://github.com/zWalterli/VUTTR.UI).

Table of Contents
=================
<!--ts-->
   * [Features](#features)
   * [Technology](#technology)
   * [Installation](#installation)
   * [How to use](#how-to-use)
   * [About](#about)
<!--te-->

### Features

- [x] CRUD Tools
- [x] Autenticação via JWT
- [x] Test Unitary & Integration
- [ ] Docker
- [ ] Azure Container Registry
- [ ] GitHub Actions

### Technology
The following tools were used in the construction of the project:

- [ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-5.0)
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [JWT](https://jwt.io/)
- [NuGet](https://www.nuget.org/)
- [Git](https://github.com/)

### Installation

## Clone this repository
    git clone git@github.com:zWalterli/VUTTR.API.git

## Navigate to the folder
    cd VUTTR.API/VUTTR.API/

## Run the migrations
    dotnet ef database update
    
## Run the API
    dotnet run

### How to use

To use the API resources, it will be necessary to make a request requesting the access token on the route API/v1/User/login.

</br>
To register with the API, the route that should be used is API/v1/User/register.

</br>
If the API/v1/auth/login route turns the status code 200, there will be a field in the response called "accessToken", and all requests within the API must have the value "Bearer" concatenated with the token for the Authorization field in the Header.

</br></br>
Here is an example of how to use this API:

### URL to use Swagger

    http://localhost:3000/swagger/index.html
    
## Register a new User

## Request
`POST /api/v1/User/register`

    curl -X POST "https://localhost:3000/api/v1/User/register" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "
    {
      "userName": "ea Excepteur ut",
      "password": "commodo Lorem dolore",
      "fullName": "cupidatat aliqua proident tempor"
    }

### Response

    {
      "userId": 47574115,
      "userName": "ea Excepteur ut",
      "password": "commodo Lorem dolore",
      "fullName": "cupidatat aliqua proident tempor",
      "refreshToken": "quis",
      "refreshTokenExpiryTime": "1990-05-19T13:33:56.853Z"
    }
    
## Signin the API

## Request
`POST /api/v1/User/login`

    curl -X POST "https://localhost:3000/api/v1/User/login" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "
    {
        "userName": "ea Excepteur ut",
        "password": "commodo Lorem dolore"
    }

### Response

    {
      "authenticated": false,
      "created": "aute est in",
      "expiration": "enim elit sint",
      "accessToken": "ut consectetur sit",
      "refreshToken": "consectetur commodo cupidatat ullamco"
    }

## Get list of Tools

## Request
`GET /api/v1/Tools`
    
    curl -X GET "http://localhost:3000/api/v1/Tools" -H  "accept: text/plain"
    
### Response

    [
      {
        "toolId": -3424924,
        "title": "nisi proident commodo tempor",
        "link": "proident dolore ea et",
        "description": "eu ut sint aute",
        "tags": [
          "api",
          "json",
          "schema"
        ]
      },
      {
        "toolId": -2491944,
        "title": "commodo mollit",
        "link": "esse consectetur eiusmod",
        "description": "occaecat sunt minim dolore",
        "tags": [
          "api",
          "json",
          "schema"
        ]
      }
    ]

## Get Tool by Id

## Request
`GET /api/v1/Tools/:id`
    
    curl -X GET "https://localhost:3000//api/v1/Tools/:id" -H  "accept: text/plain"
    
### Response
    {
     "toolId": -41629004,
     "title": "nulla amet sit ea Excepteur",
     "link": "Ut",
     "description": "exercitation amet fugiat",
     "tags": [
          "api",
          "json",
          "schema"
        ]
    }

## Create a new Tool

## Request
`POST /api/v1/Tools`

    curl -X POST "https://localhost:3000//api/v1/Tools" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "
    {
        "title": "nulla amet sit ea Excepteur",
        "link": "Ut",
        "description": "exercitation amet fugiat",
        "tags": [
          "api",
          "json",
          "schema"
        ]
    }

### Response
      {
       "toolId": -41629004,
       "title": "nulla amet sit ea Excepteur",
       "link": "Ut",
       "description": "exercitation amet fugiat",
       "tags": [
          "api",
          "json",
          "schema"
        ]
      }


## Update a Tool

### Request

`PUT /api/v1/Tools`

    curl -X PUT "https://localhost:3000//api/v1/Tools" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "
    {
        "toolId": 41629004,
        "title": "nulla amet sit ea Excepteur",
        "link": "Ut",
        "description": "exercitation amet fugiat",
        "tags": [
          "api",
          "json",
          "schema"
        ]
    }

### Response

      {
       "type": "in dolore velit ullamco minim",
       "title": "ipsum",
       "status": -22178444,
       "detail": "ut magna eiusmod laboris",
       "instance": "sit in occaecat Excepteur"
      }

## Delete a Tool

### Request

`DELETE /Contato/{id}`

    curl -X DELETE "https://localhost:3000//api/v1/Tools?id=26572573" -H  "accept: */*"
    
    Request Params
      id: 26572573

### Response

    No response body

### About
---

<a href="https://www.linkedin.com/in/walterli-valadares-j%C3%BAnior-39807a165/" target="_blank">
 <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/46723190?s=460&u=9e52942eb8201675f594e1b24eae0afa22f1aef3&v=4" width="200px;" alt=""/>
 <br />
 <sub><b>Walterli Valadares Junior</b></sub></a> <a href="https://www.linkedin.com/in/walterli-valadares-j%C3%BAnior-39807a165/" title="Linkdlin">🚀</a>


Feito com ❤️ por Walterli Valadares
<br />👋🏽 Entre em contato!
