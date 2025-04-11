# Monitoring Service For AlvaCleanCRM

## 📝 Description 

Monitoring AlvaCleanCRM Service is a lightweight console application designed to monitor and log events in the AlvaCleanCRM system.
The application runs as a completely independent service and is independent of other system components. 
It listens to messages from RabbitMQ and displays information about what is happening in the CRM system.

## Features

- Console application without UI.

- Separate service outside the main system.

- Uses RabbitMQ (producer/consumer patterns).

- Preparing for future integration with Elasticsearch Stack (ELK).

- Under test development.


## 🛠️ Technology

- C#

- .NET

- RabbitMQ


## 🛠️ Installation

### Clone the repository:
``` git clone https://github.com/ArturDavidenko/MonitoringServiceForAlvaCleanCRM.git ```

### Build the project:
``` dotnet build ```

## 🛠️ Starting RabbitMQ (Docker)
Use the following command to start RabbitMQ with an open port:
``` docker run -d --hostname rabbit-host --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management ```

## 🛠️ Configuration

No additional configuration is required. A standard RabbitMQ container with default connection settings is used.

## Project status

In development (pre-release).
The project is at the stage of testing interaction with RabbitMQ.
The goal is to test logging and further integration with ELK-stack.




