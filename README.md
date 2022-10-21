# Entity Framework Code-First Migrations Demo

This repository demonstrates how to containerize and use a .NET 6 application which utilizes Entity Framework Core Code-First migrations. Nothing fancy; just a demo app for a Friday presentation for my RSI colleagues.

> IMPORTANT NOTE: I wrote this code in about 30 minutes and it needs a bit of TLC. I will need to flesh out the CRUD endpoints a bit more, fix an issue with serializing the postId from JSON, and ensure that we're using `IConfiguration` for the connection string; instead of hard-coding it. I will make these changes ASAP. If interested, you can also fork this, make these changes, and PR it back, if you'd like a challenge.

## Local Setup

In order to get things running locally please follow the instructions below in order, starting with the prerequisites

### Prerequisites

The following tools should be installed:

- .NET 6 SDK - https://dotnet.microsoft.com/en-us/download
- Docker & Docker Compose - https://docs.docker.com/get-docker/

Once the .net CLI is installed, install the EF CLI tool by running:

```bash
dotnet tool install --global dotnet-ef
```

### Standing up the containers

To stand up both the .NET and Postgres Docker containers, run the following command from the root directory:

```bash
docker compose up
```

If you make changes to the code, you will want to re-build the image prior to bringing the container up:

```bash
docker compose up --build
```

### Performing the EF Migrations

In order to create the database schema on the running Docker Postgres instance, you will need to run the following commands from within the `/src/ORMDemo.API` directory.


> IMPORTANT NOTE: There's a bug (which I need to fix) which requires you to modify this line in `Program.cs`:

```csharp
builder.Services.AddDbContext<DemoContext>(options =>
    options.UseNpgsql("Host=postgres;Database=demo;Username=postgres;Password=demopassword")
);
```

> to be this:

```csharp
builder.Services.AddDbContext<DemoContext>(options =>
    options.UseNpgsql("Host=postgres;Database=demo;Username=postgres;Password=demopassword")
);
```

> You have to toggle between the two values to ensure that it uses the former when building the Docker image and the latter for `dotnet ef` commands. I will get this fixed soon.


First, to prepare the migrations scripts:

```bash
dotnet ef migrations add InitialCreate
```

and next, to execute said scripts against the running Postgres instance:

```bash
dotnet ef database update
```

From there, you can access the Swagger page via http://localhost:5000/swagger.
