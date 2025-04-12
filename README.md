# 🐇 Integrating RabbitMQ with .NET Aspire

This repository demonstrates how to integrate **RabbitMQ** with **.NET Aspire**, a powerful and modern framework for building scalable, cloud-native applications.

## 🚀 What is .NET Aspire?

[.NET Aspire](https://devblogs.microsoft.com/dotnet/introducing-dotnet-aspire/) is a cloud-native development stack for building distributed applications in .NET. It provides tools for service discovery, observability, configuration, and integration with popular cloud services.

## 📦 Why RabbitMQ?

**RabbitMQ** is a lightweight, open-source message broker that supports multiple messaging protocols. It’s ideal for:
- Decoupling microservices
- Handling background tasks
- Asynchronous communication
- Event-driven architectures

## 📘 Full Tutorial

Read the step-by-step integration guide here:  
🔗 [How to Integrate .NET Aspire with RabbitMQ](https://tutexchange.com/how-to-integrate-net-aspire-with-rabbitmq/)

### 📚 What You'll Learn:
- Running RabbitMQ using Docker and .NET Aspire
- Setting up Aspire to connect with RabbitMQ using `builder.AddRabbitMQ(...)`
- Publishing and consuming messages using `MassTransit`
- Viewing messages and health via RabbitMQ Management UI

## 🧰 Tech Stack

- .NET 8 / .NET Aspire
- ASP.NET Core
- RabbitMQ
- MassTransit (message bus abstraction)
- Docker

## 🛠️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Run the Project

```bash
git clone https://github.com/saineshwar/Aspire_RabbitMQ.git
cd aspire-rabbitmq-integration
dotnet run --project AspireApp
