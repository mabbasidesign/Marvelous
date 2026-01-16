# Marvelous

Marvelous is an ASP.NET Core Web API application designed to manage villas, users, and notifications. It follows a layered architecture with controllers, models, repositories, and data access layers. The project supports versioned APIs and includes authentication and notification features.

## Features
- Villa management (CRUD operations)
- User registration, login, and authentication
- Notification system
- API versioning (v1, v2)
- Pagination and API response models
- Entity Framework Core with migrations
- Docker support

## Project Structure
- **Controllers/**: API controllers for handling HTTP requests (e.g., `VillaAPIController`, `UsersController`, `NotificationController`).
- **Models/**: Data models and DTOs for villas, users, notifications, and API responses.
- **Repository/**: Repository pattern implementation for data access abstraction.
- **Data/**: Database context (`ApplicationDbContext`) and EF Core migrations.
- **Properties/**: Launch settings and publish profiles.
- **appsettings.json**: Application configuration files.
- **Dockerfile**: Containerization support.

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- (Optional) Docker

### Setup
1. **Clone the repository**
2. **Configure the database connection** in `appsettings.json`.
3. **Apply migrations**:
   ```sh
   dotnet ef database update
   ```
4. **Run the application**:
   ```sh
   dotnet run
   ```
5. **Access the API** at `https://localhost:<port>`

### Docker
To build and run with Docker:
```sh
docker build -t marvelous .
docker run -p 8080:80 marvelous
```

## API Endpoints
- `/api/v1/villa` - Villa management (v1)
- `/api/v2/villa` - Villa management (v2)
- `/api/users` - User registration and login
- `/api/notification` - Notification management

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
This project is licensed under the MIT License.
