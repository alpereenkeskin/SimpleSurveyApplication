
# Simple Survey Application

This is a simple survey application developed using ASP.NET Core.

## Features

- Create new surveys with multiple questions and choices
- Users can participate in the surveys and choose their answers
- Survey results can be viewed by admin.

## Requirements

- .NET 6 SDK
- FluentValidation                             11.6.0      11.6.0  
- Microsoft.EntityFrameworkCore                6.0.0       6.0.0   
- Microsoft.EntityFrameworkCore.Design         6.0.0       6.0.0   
- Microsoft.EntityFrameworkCore.SqlServer      6.0.0       6.0.0   
- Microsoft.EntityFrameworkCore.Tools          6.0.0       6.0.0   

## Getting Started

1. Clone the repository:
git clone https://github.com/alpereenkeskin/SurveyApplication

2. Navigate to the project directory:
cd simple-survey-app

3. Restore NuGet packages:
dotnet restore

4. Update the database with EF Core
dotnet ef database update

5. Run the application:
dotnet run

Contributions are welcome! If you find a bug or have any suggestions, please open an issue or submit a pull request.


