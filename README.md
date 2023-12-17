# demo-dotnet

Demo of .NET service

## Usage

First, install packages and build:

```sh
dotnet restore
dotnet build
```

Then, run the app:

```sh
dotnet run
```

Test the app with:

```sh
dotnet test
```

## Project Structure

This repository contains several important files and directories:

- `Program.cs`: This is the entry point of the application. It sets up the web host and starts the application.
- `Startup.cs`: This file contains configuration code for the application. It sets up the dependency injection container and the HTTP request pipeline.
- `Controllers/`: This directory contains all the controller classes for the application. Each controller handles HTTP requests to a specific route.
- `Services/`: This directory contains service classes that encapsulate the business logic of the application.
- `Models/`: This directory contains classes that represent the data models used in the application.
- `Properties/launchSettings.json`: This file contains settings for running the application in different environments.
- `appsettings.json` and `appsettings.Development.json`: These files contain configuration settings for the application.
- `Demo-dotnet.csproj`: This is the project file that includes references to all the source code files, package dependencies, and project settings.

Each of these files and directories plays a crucial role in the application. The controllers, services, and models work together to handle HTTP requests, execute business logic, and manage data.

## Resources

- [Generated assets](https://learn.microsoft.com/en-us/aspnet/core/grpc/basics?view=aspnetcore-7.0#generated-c-assets)
- [gRPC to JSON transcoding](https://learn.microsoft.com/en-us/aspnet/core/grpc/json-transcoding)
