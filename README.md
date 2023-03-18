# Games Global Assessment: Team Management System (CRUD) Backend
Built with .NET 6 using an Azure Sql server instance & db

Link to Backend API: https://backend220230317110502.azurewebsites.net

Swagger UI: https://backend220230317110502.azurewebsites.net/swagger

## Running App locally
1. Clone the repository: `git clone https://github.com/Uwais-O/GGL-TMS-BACKEND.git` and run
### Setting up and running from scratch
1. Create a new project: ASP.NET Web API
2. Install the following dependencies:
    
   Microsoft.EntityFrameworkCore.Tools
   
   Microsoft.EntityFrameworkCore.Design
   
   Microsoft.EntityFrameworkCore.SqlServer
   
   Newtonsoft.Json
   
3. Create the MVC components and run



## Setting up the backend
1. Create an Azure Sql instance and database using SQL Authentication
2. Connect the server to Visual Studio
3. Obtain the connection string and insert into the appsettings.json file
4. Ensure permissions are allowed by inserting the following into Program.cs:
  
    `app.UseCors(policy => policy.AllowAnyHeader()`
    
    `.AllowAnyMethod()`
   
   `.SetIsOriginAllowed(origin => true)`
   
    `.AllowCredentials());`
    
5. Use the NuGet PM, create migration files using: `add-migration <migration name/msg>`
6. Create the database and update using: `update-database` 

## Deploying
1. Open your Visual Studio project that contains the web API you want to deploy.

2. Right-click on the project in the Solution Explorer and select "Publish."

3. In the "Publish" window, select "Azure" as your target and choose the appropriate Azure subscription and resource group.

4. Choose the type of Azure App Service you want to use to host your web API.

5. Configure the App Service settings such as name, location, and pricing tier.

6. On the "Summary" page, review your settings and click "Publish" to deploy your web API to Azure.

7. Wait for the deployment to complete, and then verify that your web API is running in Azure by navigating to its URL in a web browser.


## Issues
1. Some NUnit tests failed, due to unfamiliarity with testing syntax and structure
