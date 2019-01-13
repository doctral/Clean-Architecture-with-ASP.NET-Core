# Clean Architecture with ASP.NET Core and Angular 6

## Useful Resources
1. [Remove Files from Git After Adding/Updating .Gitignore](https://eric.blog/2014/05/11/remove-files-from-git-addingupdating-gitignore/)
2. [Edit Visual Studio Templates for new C# Class/Interface](https://stackoverflow.com/questions/2072687/how-do-i-edit-the-visual-studio-templates-for-new-c-sharp-class-interface)
3. [Get SQL Server Connection String from Visual Studio](https://www.codeproject.com/Tips/592675/Get-SQL-Server-Database-Connection-String-Easily-f) 
4. [Unit Testing C# with NUnit and .NET Core](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit)
5. [Covariance & Contravariance in C#](http://geekswithblogs.net/abhijeetp/archive/2010/01/10/covariance-and-contravariance-in-c-4.0.aspx)

## Clean Architecture

### Database Project
1. Database table sql files
2. Database seeding sql files
3. Post-deployment sql files
4. Publish database project to SQL server

### IoC Project
1. [Autofac](https://autofaccn.readthedocs.io/en/latest/getting-started/index.html) is an IoC container which provides base class for user-defined modules. With Autofac, we can craete a **ContainerBuilder** and register **components** with it.  
2. [System.Reflection.Assembly](https://docs.microsoft.com/en-us/dotnet/api/system.reflection?view=netframework-4.7.2) can be used to load **Assemblies**.

### Domain Project
1. Audit: general classes for shared Created/Modified/Deleted Date/Id
2. Entity classes

### Persistence Project
1. [ASP.NET EntityFramework Core](https://docs.microsoft.com/en-us/ef/core/)
2. Dependencies: Microsoft.EntityFrameworkCore & Microsoft.EntityFrameworkCore.SqlServer
3. Create Entity Config for each table
4. Implement DbContext, which is a combination of Unit of Work and Repository patterns 
5. Implement Queries and Commands
6. To enable buld insert/update/delete, we can use an open-source lib: z.EntityFramework.Plus for entity framework core. 

### Application Project
1. Interface of Queries and Commands
    1. Command: does something, should modify state, should not return a value
    2. Query: answers a question, should not modify state, should return a state
2. Dtos: CreateDto, ModifyDto, etc
3. Manager Interface and Implementation

### RESTful Api Project
1. Start and Program: Implement Config and ConfigService
2. Config CORS
3. Follow RESTful principles
4. Other supporting functions using query string: pagination, filtering, and searching
    1. Paging: helps avoid performance issues
    2. Filtering: Limits the collection resource, taking into account a predicate
    3. Searching: Limits the collection resource by passing a search predicate
5. Hypermedia as the Engine of Application State (HATEOAS):
    1. Functions:
        1. Helps with evolvability and self-descriptiveness
        2. Hypermedia drives how to consume and use the API
6. Working with Caching: Http Caching 
     1. Each response should define itself as cacheable or not
     2. Cache types: 
        1. Client Cache: lives on the client private cache, reduces bandwidth requirements, and less requests from cache to API. i.e: Angular, Marvin.HttpCache, etc
        2. Gateway cache: lives on the server shared cache, doesn't save bandwidth between cache and API, and drastically lowers requests to the API
        3. Proxy cache: lives on the network shared cache
    3. Expiration Model: 
    4. Validation Model: check the freshness of a response that has been cached
        1. Strong validators: change if the body or headers of a response change, and can be used in any context
        2. Weak validators: don't always change when the response changes
    5. Combine Expiration Model and Validation Model
    6. Add middleware to support cache header 
7. Working with Concurrency
    1. Pessimistic Concurrency: 
        1. Resource is locked 
        2. While it's locked, it cannot be modified by another client
        3. This is not possible in REST
    2. Optimistic concurrency:
        1. Token is returned together with the resource
        2. The update can happen as long as the token is still valid
        3. ETags are used as validation tokens
8. Rate Limiting and Throtting: Limit the amount of allowed requests to API per hour/day per IP, etc.
    1. Add middleware to configure the rate limit

### Test Project
1. Unit of Work: Everything that happens from invoking a public method to it returning the results after it's finished. It's the work done along the path you see the debugger take through your code.
2. Unit Test: Single class, behavior, drive implementation, and fake data access layer
3. Integration Test: System, interaction, regression catch, test data access layer
    1. Reinitialize database for every test run
        1. Create before tests
        2. Clean up after tests
    2. Be resilient
        1. Delete if it already exists
        2. Close existing connections
    3. Run migrations
        1. EF6: MigrateDatabaseToLatestVersion
        2. EF Core: Database.Migrate()
4. Test Names: Descriptive test names are very important, particularly as your test suites grow. A good practice is: **[Subject]_[Scenario]_[Result]**, for example: *GrantLoan_WhenCreditLessThan500_ReturnFalse*.        
5. Fake: a replacement of a real dependency with something the test specifies. 
6. Requirements: 
    i). Read code >> Write Code
    ii). Consistent, meaningful names
    iii). Clear and simple tests
    iv). Precise test scenarios: test one expectation per test; Multiple asserts on same object can be OK; Test should point to precise location of problem.

### Infrastructure Project
1. Message: can be used to log any type of system messages: error, info, success, warning
2. ManagerResult: record the operation status with Message
3. File input & output
4. Some other functions that can be used to support the application  

### UI Project (Angular 6)
1. Core Module
    1. Authorization/Authentication
    2. Http-Interceptors: error-handling, auth-interceptor
    3. Language localization/translation
    4. Other supporting components & routings: page-not-found, not-authorized, error-happened, etc
2. Feature Modules: features and functionalities of the app
3. Shared Modules

## ASP.NET Core: Cross-platform, high-performance, and open-source framework

### Useful Resources
1. [Official Documentation](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.2)

### ASP.NET VS ASP.NET CORE
1. Cross-platform.
    1. ASP.NET Core build for Windows, macOS, and Linux
    2. ASP.NET 4.x build for Windows
2. Improved performance: ASP.NET Core has better performance than ASP.NET
3. Side-by-side versioning.
    1. ASP.NET Core allows multiple versions per machine
    2. ASP.NET allows only one version per machine
4. New APIs: ASP.NET Core provides a lightweight, high-performance, and modular HTTP request pipeline that supports multiple data format and content negotiation, as well as model binding & model validation. 
5. Open source

### .NET VS .NET Core
1. Use .NET Core for your server application when:
    1. requires cross-platform
    2. targeting [microservices](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/index) 
    3. using Docker containers
    4. need high-performance and scalable systems
    5. need side-by-side .NET version per application
2. Use .NET for server application when:
    1. currently use .NET framework
    2. using third-party libraries or packages that not available for .NET Core
    3. use .NET technologies that are not available for .NET Core
    4. use a platform that doesn/t support .NET Core

### ASP.NET Core Fundamentals
1. Overview: 
    1. Program.cs: create a web server in the Main method as a managed entry point for the app, and invokes CreateWebHostBuilder that create a web host and defines a web server.
    2. Startup.cs: configure services required by the app and define the request handling pipeline. it contains two methods:
        1. Configure: used to configure the HTTP request pipeline and defines the middleware called in the request pipeline.
            1. used to specify how the app responds to HTTP requests
            2. Adding middleware components to an IApplicationBuilder instance
        2. ConfigureServices (optional): used to add services to the container including ASP.NET Core MVC, Entity Framework Core, Identity, etc. Called by the web host before the Configure method to configure the app's services.
    3. Dependency Injection & Inversion of Control: ASP.NET Core provides a native IoC container that supports constructor injection by default. Services are made available through Dependency Injection (DI).
    4. Middleware: in configure method, middleware can be added to the pipeline by invoking a UseXXX extension method. ASP.NET Core middleware performs asynchronous operations on an HttpContext and then either invokes the next middleware in the pipeline or terminates the request.
    5. Logging.
    6. Error handling. 
2. Extend Startup with startup filters: Use IStartupFilter to configure middleware at the beginning or end of an app's Configure middleware pipeline. Middleware execution order is set by the order of IStartupFilter registrations.
3. Service lifetimes: Transient, Scoped, Singleton
    1. Transient: services are created each time they are requested. This lifetime works best for lightweight, stateless services.
    2. Scoped: Scoped lifetime services are created once per request. When using a scoped service in a middleware, inject the service into the Invoke or InvokeAsync method. Don't inject via constructor injection because it forces the service to behave like a singleton.
    3. Singleton: Singleton lifetime services are created the first time they're requested (or when ConfigureServices is run and an instance is specified with the service registration). Every subsequent request uses the same instance.
4. Middleware: Middleware is software that's assembled into an app pipeline to handle requests and responses. Each component chooses whether to pass the request to the next component in the pipeline, and can perform work before and after the next component in the pipeline is invoked.
    1. Create a middleware pipeline with IApplicationBuilder: The ASP.NET Core request pipeline consists of a sequence of request delegates, each delegate can perform operations before and after the next delegate. A delegate can also decide to not pass a request to the next delegate.
    2. Middleware Order: The order that middleware components are added in the Startup.Configure method defines the order in which the middleware components are invoked on requests and the reverse order for the response. The order is critical for security, performance, and functionality.
    3. Build-in middleware: Authentication, CORS, MVC, Session, etc.
    4. Write Middleware: Middleware is generally encapsulated in a class and exposed with an extension method.

