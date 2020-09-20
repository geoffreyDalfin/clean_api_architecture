# Clean .net core api architecture

Presentation of clean web api architecture in .net core improving of [microsoft documentation](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio).

This repository includes the best practices of a quality architectural realization such as the principles SOLID, DRY, repository pattern, async/await, etc..

The practices listed above are necessary to provide a quality API.

- [Get started](#getting-started)
- [API overview](#api-overview)
- [Fundamentals](#fundamentals)

## Get started
------
Some basic Git commands to pull this project of the repo and build it:
```
git clone https://github.com/geoffreyDalfin/clean_api_architecture.git
dotnet restore && build && run
```
## API overview
-----
| Command | Description | Request Body | Response Body
| --- | --- | --- | ---
| GET `/api/v1/book` | Get all book| None | Books array
| GET `/api/v1/book/{id}` | Get a book by identifier | None | Unique book
| POST `/api/v1/book` | Create new book | A book item | Created book
| PUT  `api/v1/book/` | Update an existing book | A book item | None
| DELETE  `api/v1/book/` | Remove selected book | None | None


## Fundamentals
------
This part describes the different important points in the design of a quality API.
- [Dependency injection principle](#dependency-injection-principle)


## Dependency injection principle 
Dependency injection principle avoids strong links between dependencies and solves the use of unit testing.

To use dependence injection, you have to : 
 - Use an interface or base class abstraction.
 - Register the link between the abstraction and its implementation class in a service container.

During registration, you can define the lifetime of a service appropriate to our needs :

| Lifetime | Description | Method |
|----------|-------------|--------|
|Transient |Created each time they're requested from the service container |AddTransient<TAbstraction,TImplementation>
|Scoped    |Created once per client request |AddScoped<TAbstraction,TImplementation>
|Singleton |Created at the first time they're client requested|AddSingleton<TAbstraction,TImplementation>


```csharp
//add abstraction reference in the service container
services.AddSingleton<IBookRepository, BookRepository>();
```
