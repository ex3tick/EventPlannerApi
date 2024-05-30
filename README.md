
# Event Management System

## Overview
This is an event management system built with ASP.NET Core. It provides APIs to manage users, events, registrations, and tickets. This document explains the functionalities of the system and includes the necessary SQL statements to set up the database.

## Features
- **User Management**: Create, retrieve, update, and delete users.
- **Event Management**: Create, retrieve, update, and delete events.
- **Registration Management**: Register users to events and manage registrations.
- **Ticket Management**: Create, retrieve, update, and delete tickets for events.

## API Documentation
### User API
- **GET /api/User/AllUsers**: Retrieves all users.
- **GET /api/User/GetUserById?id={id}**: Retrieves a user by ID.
- **POST /api/User/InsertUser**: Inserts a new user. *Body: User*
- **PUT /api/User/UpdateUser**: Updates an existing user. *Body: User*
- **DELETE /api/User/DeleteUser?id={id}**: Deletes a user by ID.
- **GET /api/User/EmailExists?email={email}**: Checks if an email exists in the database.
- **Get /api/User/GetUserByEmail?email={email}**: Retrieves a user by email.

### Event API
- **GET /api/Event/AllEvents**: Retrieves all events.
- **GET /api/Event/GetEventById?id={id}**: Retrieves an event by ID.
- **POST /api/Event/InsertEvent**: Inserts a new event. *Body: Event*
- **PUT /api/Event/UpdateEvent**: Updates an existing event. *Body: Event*
- **DELETE /api/Event/DeleteEvent?id={id}**: Deletes an event by ID.

### Registration API
- **GET /api/Registration/AllRegistrations**: Retrieves all registrations.
- **GET /api/Registration/GetRegistrationById?id={id}**: Retrieves a registration by ID.
- **POST /api/Registration/InsertRegistration**: Inserts a new registration. *Body: Registration*
- **PUT /api/Registration/UpdateRegistration**: Updates an existing registration. *Body: Registration*
- **DELETE /api/Registration/DeleteRegistration?id={id}**: Deletes a registration by ID.

### Ticket API
- **GET /api/Ticket/AllTickets**: Retrieves all tickets.
- **GET /api/Ticket/GetTicketById?id={id}**: Retrieves a ticket by ID.
- **POST /api/Ticket/InsertTicket**: Inserts a new ticket. *Body: Ticket*
- **PUT /api/Ticket/UpdateTicket**: Updates an existing ticket. *Body: Ticket*
- **DELETE /api/Ticket/DeleteTicket?id={id}**: Deletes a ticket by ID.
- **GET /api/Ticket/GetTicketsByEventId?id={id}**: Retrieves tickets by event ID.

## Database Setup
Run the following SQL statements to set up the necessary database tables.

### Users Table
```sql
CREATE TABLE users
(
    id        INT AUTO_INCREMENT PRIMARY KEY,
    firstname VARCHAR(50),
    lastname  VARCHAR(50),
    email     VARCHAR(100) UNIQUE,
    wantAlert BOOLEAN,
    password  VARCHAR(255),
    salt      VARCHAR(255),
    isPlaner  BOOLEAN,
    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE INDEX idx_users_email ON users (email);
```

### Events Table
```sql
CREATE TABLE events
(
    id        INT AUTO_INCREMENT PRIMARY KEY,
    eventName VARCHAR(100),
    ort       VARCHAR(100),
    datum     DATETIME,
    infos     TEXT,
    idPlaner  INT,
    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idPlaner) REFERENCES users (id)
);

CREATE INDEX idx_events_name ON events (eventName);
CREATE INDEX idx_events_idplaner ON events (idPlaner);
```

### Registrations Table
```sql
CREATE TABLE registrations
(
    id        INT AUTO_INCREMENT PRIMARY KEY,
    idEvents  INT,
    idUsers   INT,
    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idEvents) REFERENCES events (id),
    FOREIGN KEY (idUsers) REFERENCES users (id)
);
```

### Tickets Table
```sql
CREATE TABLE tickets
(
    id        INT AUTO_INCREMENT PRIMARY KEY,
    idEvents  INT,
    cost      DECIMAL(10, 2),
    createdAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idEvents) REFERENCES events (id)
);

CREATE INDEX idx_tickets_event ON tickets (idEvents);
```

## Configuration
### Connection String
After setting up the database, add your connection string to the `appsettings.json` file in your ASP.NET Core project. Here is an example configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
  }
}
```

Replace `your_server`, `your_database`, `your_username`, and `your_password` with your actual database server name, database name, username, and password.

## Getting Started
1. Clone the repository.
2. Set up the database using the provided SQL statements.
3. Configure the database connection in the `appsettings.json` file.
4. Run the application using your preferred method (e.g., Visual Studio, command line).
