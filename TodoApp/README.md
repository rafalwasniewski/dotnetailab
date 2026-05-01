# Todo App

A simple .NET 10.0 web application that displays "AI qwen3-coder-30b" at the root endpoint.

## Features

- Displays "AI qwen3-coder-30b" when accessing the root URL
- Self-hosted with Kestrel server
- Dockerized for containerization

## Running Locally

```bash
dotnet run
```

## Building

```bash
dotnet build
```

## Publishing

```bash
dotnet publish -c Release
```

## Docker

```bash
docker build -t todo-app .
docker run -p 8080:8080 todo-app
```

The application will be available at http://localhost:8080