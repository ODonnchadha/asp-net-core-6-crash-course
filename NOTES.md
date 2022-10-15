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