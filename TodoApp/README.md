# Modern Todo List App

A modern .NET 10.0 web application that provides a complete to-do list functionality.

## Features

- Add new todo items
- List existing todos
- Mark todos as done
- Delete completed todos
- Responsive design using Bootstrap
- In-memory database storage

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