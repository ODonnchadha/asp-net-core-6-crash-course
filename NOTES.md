## ASP.NET Core 6 Crash Course

- OVERVIEW:
  - dotnet CLI. MVC pattern. EF Core 6. Razor View syntax & tag helpers. ASP.NET Identity for authentication.

- GETTING READY:
  - Housekeeping: 
    - Compelling: Cross-platform. Experience and Documentation. Performance. Open source.
    - VSCode. ASP.NET Core 6. Visual Studio 2022. Rider 2021.
  - Carved Rock Fitness. Online retailer. Administrsation tool for managing products and their associated categories.
  - VS Code as the primary editor with Visual Studio or Rider for some scaffolding.
    ```javascript
      dotnet new mvc -n CarvedRock.Admin
      code .
    ```
  - Run and debug:
    ```javascript
      dotnet dev-certs https --help
      dotnet dev-certs https -t
    ```

- ADDING CONTROLLERS, VIEWS, & MODELS
  - [CTRL + ,] to view settings.
  - Tag helpers:
    ```javascript
      asp-controller="Products" asp-action="Index"
    ```
    - Model! (Let the compiler know that the model will not be null.)

- ADDING A DAABASE:
  - APproach:
    - Use EF Core.
    - Object/Relational Mapper (ORM) (Hibernate, Active Record.)
    - Tables, schemas managed within a DbContext.
    - Migrations to apply, or reverse, change.
    - Providers. SQLite.

    - Ensure that you are in the *.csproj directory:
    ```javascript
      dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    ```
    - For migrations, you need the global EF tool installed for the .NET CLI:
    ```javascript
      dotnet tool install -global dotnet-ef
      dotnet add package Microsoft.EntityFrameworkCore.Design
      dotnet ef migrations add Initial
      dotnet ef database update
    ```
    - Add the "SqlLite" extension.
    - [CTRL + SHIFT + P] to bring up the command pallet.
      ```javascript
        SqlLite: Open Database
      ```
      - SQLLITE EXPLORER is added to explorer window.
      - Scaffolding expedites the process of building but was never intended to be part of the finished product.
        ```javascript
          dotnet tool install -g dotnet-aspnet-codegenerator
          dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
          dotnet-aspnet-codegenerator controller -name ProductsControllerDb -namespace CarvedRock.Admin.Controllers -model CarvedRock.Admin.Entities.Product -dataContext CarvedRock.Admin.Contexts.ProductContext
        ```
        - NOTE: Scaffolding failed.
      - Scaffolding: No seperation of concern.
  
- WORKING WITH VIEWS:
  - UI. Deeper understanding of Views and how they work.
  - Three key View files:
    - _ViewImports.cshtml: Common namespace imports, tag helper definitions.
    - _ViewStart.cshtml: Indetifies layout for views.
    - _Layout.cshtml: Layout (App Shell) content. and @RenderBody(). Can have a local CSS File. (CSS Isolation.)
    - NOTE: Instances of these files can exist in View subdirectories.
  - Server-side validation.
  - Within Shared folder: _ValidationScriptsPartial.
  - logger.LogInformation() within console.

- ADDING RELATED DATA:
  - Adding a product category. Db changes. Web application updated to reflect. Read. Then update.