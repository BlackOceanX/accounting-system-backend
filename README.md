# Accounting System Backend

A modern accounting system backend built with .NET 9.0, providing robust APIs for expense management and accounting operations.

## 🚀 Features

- RESTful API endpoints for expense management
- PostgreSQL database integration
- Entity Framework Core for data access
- Swagger/OpenAPI documentation
- CORS support
- Modern .NET 9.0 architecture

## 🛠️ Prerequisites

- .NET 9.0 SDK
- PostgreSQL database
- Your favorite IDE (Visual Studio, VS Code, etc.)

## 📦 Installation

1. Clone the repository:
```bash
git clone [repository-url]
cd accounting-system-backend
```

2. Update the database connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=accounting_db;Username=your_username;Password=your_password"
  }
}
```

3. Run database migrations:
```bash
dotnet ef database update
```

4. Run the application:
```bash
dotnet run
```

The API will be available at `https://localhost:5001` and the Swagger UI at `https://localhost:5001/swagger`.

## 🏗️ Project Structure

- `Controllers/` - API endpoints and request handling
- `Services/` - Business logic layer
- `Repositories/` - Data access layer
- `Entities/` - Database models and entities
- `Migrations/` - Database migration files

## 🔧 Configuration

The application can be configured through the following files:
- `appsettings.json` - Main configuration file
- `appsettings.Development.json` - Development-specific settings

## 📚 API Documentation

API documentation is available through Swagger UI when running the application. Access it at the root URL of the application.

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.