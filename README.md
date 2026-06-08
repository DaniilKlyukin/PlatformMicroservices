# PlatformMicroservices

This is a training project built to understand the core concepts of microservices architecture on the .NET platform. The project is based on the ".NET Microservices – Full Course" by Les Jackson.

## Features & Technologies

*   **Framework:** .NET Core / .NET 6 (or your version)
*   **Services:**
    *   *Platform Service* (for managing software platforms)
    *   *Command Service* (for managing CLI commands related to platforms)
*   **Communication:**
    *   Synchronous inter-service communication via **gRPC** and **HTTP Client**
    *   Asynchronous event-driven communication via **RabbitMQ** (Message Broker)
*   **API Gateway:** Routing with **Ocelot**
*   **Infrastructure:**
    *   Containerization with **Docker**
    *   Orchestration and deployment using **Kubernetes** (Services, Deployments, Ingress)
    *   Database management with Entity Framework Core (SQL Server & In-Memory DB)