## Loyalty System API
A simple customer loyalty application. This repository is intended for demonstrating best practices in software development. In real-world applications, these practices should be selected based on the specific requirements of each project.

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
  - __xUnit__ for unit testing
  - __Moq__ for mocking
  - __FluentValidation__ for server-side validation
  - __Serilog__ for logging in console and text file
  - __MediatR__ for implementing mediator pattern
  - __Mapster__ for object mapping

      
## Run with Docker

#### 1. Start with Docker compose

Run the following command in project directory:

```
docker-compose up -d
```

Docker compose in this application includes 3 services:

- __Web API application__ will be listening at `http://localhost:5000`

- __Postgres database__ will be listening at `http://localhost:5433`

- __PgAdmin4 web interface__ will be listening at `http://localhost:8000`


#### 2. Run the migrations

Open `Loyalty.sln` file in visual studio, then in package manager console tab, run:

```
update-database
```

This command will generate the database schema in postgres container.



