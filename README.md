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
