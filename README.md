# Raw-Dependency-Injection-Implementation
This project demonstrates a custom-built dependency injection framework with lifetime management in C#. It showcases the use of interfaces, service registration, and dependency resolution, including support for Singleton and Transient lifetimes. 


# DependencyInjectionDemo

### Repository: [semirhamid/Raw-Dependency-Injection-Implementation](https://github.com/semirhamid/Raw-Dependency-Injection-Implementation)

## Description

This project demonstrates a custom-built dependency injection framework with lifetime management in C#. It showcases the use of interfaces, service registration, and dependency resolution, including support for Singleton and Transient lifetimes. The codebase is structured to be modular, scalable, and easily testable, making it an excellent showcase for advanced software architecture and design patterns.

## Features

- **Custom Dependency Injection:** Implemented a simple yet effective DI container from scratch.
- **Lifetime Management:** Supports Singleton and Transient lifetimes for registered services.
- **Interface-Based Design:** Classes are decoupled from their implementations using interfaces, improving testability and maintainability.
- **Modular Structure:** The code is organized into modular components, demonstrating best practices in software architecture.

## Getting Started

### Prerequisites

- .NET SDK 6.0 or later

### Running the Application

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/semirhamid/Raw-Dependency-Injection-Implementation.git
   cd DependencyInjectionDemo
    ```
2. Build the Project:
    ```
    dotnet build
    ```
3. Run the Application:
   ```
   dotnet run
   ```

Usage
The application demonstrates the following:

Registering services with different lifetimes (Singleton and Transient).
Resolving services and their dependencies automatically.
Using interfaces to decouple implementations from their contracts.
Code Overview
Program.cs: The entry point of the application where services are registered and resolved.
DependencyInjection.cs: Contains the custom DI container logic, including service registration and resolution with lifetime management.
HelloWorld.cs: Example classes (HelloWorld, MyName, and PrinterStarter) demonstrating dependency injection.
