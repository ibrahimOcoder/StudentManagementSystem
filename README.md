# Overview
The Student Management System is an advanced application designed to handle various administrative, teaching, and student-related tasks in an educational setting. Built with .NET Core, the system leverages microservices architecture to provide a scalable and efficient solution. Key technologies include RabbitMQ for messaging, AutoMapper for data transformation, and Entity Framework Core (EF Core) for data management.

# Key Technologies
**.NET Core:** A cross-platform framework that enables the development of high-performance, scalable applications.
**Microservices:** An architectural pattern that decomposes the application into small, loosely coupled services, each responsible for a specific aspect of the system.
**Entity Framework Core (EF Core):** An ORM framework that facilitates data access and manipulation, supporting various database providers.
**RabbitMQ:** A robust messaging broker used for inter-service communication, ensuring reliable message delivery.
**AutoMapper:** A library that simplifies the mapping between different object models.
**Unit of Work Pattern:** Ensures reliable message delivery and transaction management through RabbitMQ, implementing the event integration pattern.
**Repository Pattern:** Utilized with DbContext to abstract data access logic and manage data operations effectively.

# Architecture
**Microservices Architecture:** The application is divided into separate, independent services (Admin, Teacher, Student) to enhance modularity and scalability.
**RabbitMQ:** Facilitates asynchronous communication and reliable message delivery between microservices, implementing the event integration pattern.
**Unit of Work Pattern:** Ensures reliable transaction management and message delivery, supporting the event-driven architecture.
**Repository Pattern:** Applied with DbContext to abstract data access and manage database interactions.
**Worker Services:** Each microservice includes a worker service that listens for and processes messages via RabbitMQ.
**Message Handling Service:** A dedicated project for sending messages, completing the event integration pattern and ensuring effective communication across the system.

# Business Modules
## Admin Module
### Features:
1. Add new teachers and students to the system.
2. Assign courses to both teachers and students.
3. Manage user roles and permissions.

### Responsibilities:
1. Oversee the overall management of the system.
2. Ensure proper course assignments and maintain user records.

## Teacher Module
### Features:
1. Upload and manage student marks for assigned courses.
2. View and update course-related information.
   
### Responsibilities:
1. Track and report on student performance.
2. Ensure accurate and timely entry of marks.

## Student Module
### Features:
1. View academic marks and performance for enrolled courses.
2. Access course materials and updates.
   
### Responsibilities:
1. Monitor personal academic progress.
2. Stay updated on course-related information.
