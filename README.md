## Web API Application

This repository is a sample ASP.NET Core Web API (.NET 8) project.


## Avaliable endpoints

The endpoints can be tested using postman or swagger.


<details>
  
<summary>Login</summary>

```
Post    http://localhost:5000/api/identity/login
```

##### Input from body:

```
Content-Type: application/json
{
  "userName": "sara",
  "password": "123456"
}
```

</details>


<details>
  
<summary>Get User</summary>

 <h6>Needs authorization </h6>

```
GET    http://localhost:5000/api/users/{userId}
```


</details>



<details>
  
<summary>Earn Points</summary>

 <h6>Needs authorization </h6>

```
Post    http://localhost:5000/api/users/{userId}/earn
```

##### Input from body:

```
Content-Type: application/json
{
  "points": 100
}
```

</details>





## Tech Stack
  -	ASP.NET Core Web API -v8
  - Entity Framework Core -v8
  - TDD (Test-Driven Development)
  - DDD (Domain-Driven Design)
  - Clean Architecture
  - Clean Code
  - Repository Design Pattern
  - CQRS Design Pattern
  - Mediator Design pattern
  - JWT (JSON Web Token) for Authentication & Authorization
  - PostgreSQL Database
  - Redis for Caching
  - Docker


<details>

  
<summary>Nuget Packages</summary>

 <h4>Here is a list of some of the nuget packages used in this repository :</h4>

  - __xUnit__ for unit and integration testing
  - __Testcontainers__ for integration testing
  - __Moq__ for mocking
  - __Serilog__ for logging in console and text file
  - __FluentValidation__ for server-side validation
  - __FluentAssertions__ for test assertions
  - __MediatR__ for implementing mediator pattern
  - __Mapster__ for object mapping
  - __Newtosoft.Json__ for serializing and deserializing objects
  - __Microsoft.Extensions.Caching.StackExchangeRedis__ for implementing redis cache
    

</details>

  
## Get started

#### 1. Clone the repository

```
git clone https://github.com/SaraRasoulian/Loyalty-System-API.git
```
#### 2. Start with Docker compose

Make sure [docker](https://docs.docker.com/get-docker/) is installed on your machine.

Run the following command in project directory:

```
docker-compose up -d
```

Docker compose in this project includes 4 services:

- Web API application will be listening at `http://localhost:5000`

- Postgres database will be listening at `http://localhost:5433`

- PgAdmin4 web interface will be listening at `http://localhost:8080`
 
- Redis cache will be listening at `http://localhost:6379`


To apply your modified code, you can add build option:

```
  docker-compose up -d --build
```

To stop and remove all containers, use the following command:

```
  docker-compose down
```


#### 3. Run the migrations

Open `CustomerLoyalty.sln` file in visual studio, then in package manager console tab, run:

```
update-database
```

This command will generate the database schema in postgres container.

---

Make sure Docker engine is running, before running the integration tests.


