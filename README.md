# Simple Survey Application

This is a simple survey application developed using ASP.NET Core.

## Features

-Users can create requests by providing their names, email addresses, and request details.
-The created requests are displayed in a list format on the main page.
-Admin users can manage the requests (approve, reject, delete).


## Requirements

   > .NET 6 SDK
   > FluentValidation                             11.6.0      11.6.0  
   > Microsoft.EntityFrameworkCore                6.0.0       6.0.0   
   > Microsoft.EntityFrameworkCore.Design         6.0.0       6.0.0   
   > Microsoft.EntityFrameworkCore.SqlServer      6.0.0       6.0.0   
   > Microsoft.EntityFrameworkCore.Tools          6.0.0       6.0.0   

## Getting Started

1. Clone the repository:
  gh repo clone alpereenkeskin/SimpleSurveyApplication

2.Navigate to the project directory:
  cd anketdeneme

3.Restore NuGet packages:
  dotnet restore

4.Update the database with EF Core:
  dotnet ef database update

5.Run the application:  
  dotnet run
