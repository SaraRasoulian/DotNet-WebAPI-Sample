## Loyalty System API
A simple customer loyalty application.

This repository is intended for demonstrating best practices in software development. In real-world applications, these practices should be selected based on the specific requirements of each project.

## Avaliable endpoints

The endpoints can be tested using postman or swagger.

##### Earn points (needs authorization):
```
Post    http://localhost:5000/api/users/{id}/earn
```

###### Input from body:
```
Content-Type: application/json
{
  "points": 100
}
```

----


##### Login:
```
Post    http://localhost:5000/api/identity/login
```

###### Input from body:
```
Content-Type: application/json
{
  "userName": "sara",
  "password": "123456"
}
```


## Technology Stack
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
  - Database built via Entity framework migrations (code-first approach)
  - Docker

#### Nuget Packages
  - __xUnit__ for unit and integration testing
  - __Testcontainers__ for integration testing
  - __Moq__ for mocking
  - __FluentValidation__ for server-side validation
  - __Serilog__ for logging in console and text file
  - __MediatR__ for implementing mediator pattern
  - __Mapster__ for object mapping

      
## Get started

#### 1. Clone the repository

```
git clone https://github.com/SaraRasoulian/Loyalty-System-API.git
```
#### 2. Start with docker compose

Make sure [docker](https://docs.docker.com/get-docker/) is installed on your machine.

Run the following command in project directory:

```
docker-compose up -d
```

Docker compose in this project includes 3 services:

- Web API application will be listening at `http://localhost:5000`

- Postgres database will be listening at `http://localhost:5433`

- PgAdmin4 web interface will be listening at `http://localhost:8080`


To apply your modified code, you can add build option:

```
  docker-compose up -d --build
```

To stop and remove all containers, use the following command:

```
  docker-compose down
```


#### 3. Run the migrations

Open `Loyalty.sln` file in visual studio, then in package manager console tab, run:

```
update-database
```

This command will generate the database schema in postgres container.

---

Make sure Docker engine is running, before running the integration tests.


