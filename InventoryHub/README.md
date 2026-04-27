# InventoryHub - Full Stack Integration Project

## Overview

InventoryHub is a complete, production-ready inventory management system built with ASP.NET Core and Blazor. This project demonstrates seamless integration between a modern front-end and a robust back-end API, showcasing best practices in full-stack development including error handling, CORS configuration, JSON structuring, and performance optimization.

## Project Structure

```
InventoryHub/
├── ClientApp/                 # Blazor WebAssembly Frontend
│   ├── Components/
│   │   └── Pages/
│   │       ├── Home.razor    # Landing page
│   │       └── FetchProducts.razor    # Product listing component
│   ├── wwwroot/              # Static files
│   │   ├── index.html
│   │   └── appsettings.json
│   ├── Program.cs            # Application startup configuration
│   ├── App.razor             # Root component
│   ├── app.css               # Styling
│   └── ClientApp.csproj      # Project configuration
│
├── ServerApp/                # Minimal API Backend
│   ├── Program.cs            # API endpoints and middleware configuration
│   ├── Properties/
│   │   └── launchSettings.json    # Server configuration
│   ├── appsettings.json      # Application settings
│   ├── appsettings.Development.json
│   └── ServerApp.csproj      # Project configuration
│
├── FullStackSolution.sln     # Solution file
├── README.md                 # This file
└── REFLECTION.md             # Development process summary
```

## Technology Stack

- **Frontend**: Blazor WebAssembly (C#, .NET 8.0)
- **Backend**: ASP.NET Core Minimal APIs (.NET 8.0)
- **Communication**: HTTP/REST with JSON serialization
- **Styling**: CSS3 with responsive design
- **Development Environment**: Visual Studio Code, .NET CLI

## Features

### Backend API (ServerApp)

- **RESTful endpoints** for product data retrieval
- **CORS configuration** for secure cross-origin requests
- **JSON response formatting** with nested category objects
- **Error handling** with meaningful HTTP status codes
- **Multiple endpoints**:
  - `GET /api/productlist` - Retrieve all products
  - `GET /api/productlist/{id}` - Retrieve a specific product
  - `GET /api/productlist/category/{categoryId}` - Filter by category

### Frontend (ClientApp)

- **Product listing** with real-time data from the API
- **Category filtering** for easier product browsing
- **Error handling** with user-friendly messages
- **Loading states** for better UX
- **Responsive design** that works on desktop and mobile devices
- **Stock level indicators** showing product availability

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio Code or Visual Studio 2022
- Git (for version control)

### Installation

1. Navigate to the project directory:
```bash
cd InventoryHub
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the solution:
```bash
dotnet build
```

### Running the Application

#### Option 1: Using Two Terminal Windows

Terminal 1 - Run the Backend Server:
```bash
cd ServerApp
dotnet run
```
The API will be available at `http://localhost:5221`

Terminal 2 - Run the Frontend:
```bash
cd ClientApp
dotnet run
```
The application will open in your browser at `http://localhost:5000`

#### Option 2: Using Visual Studio

1. Open `FullStackSolution.sln` in Visual Studio
2. Set both ClientApp and ServerApp as startup projects
3. Press F5 to run

### API Endpoints

#### Get All Products
```
GET /api/productlist
```

Response:
```json
[
  {
    "id": 1,
    "name": "Laptop",
    "price": 1200.50,
    "stock": 25,
    "category": {
      "id": 101,
      "name": "Electronics"
    }
  }
]
```

#### Get Product by ID
```
GET /api/productlist/1
```

#### Get Products by Category
```
GET /api/productlist/category/101
```

## Code Highlights

### Frontend: HTTP Client Integration

The ClientApp uses `HttpClient` to communicate with the backend API:

```csharp
// HttpClient injected and configured in Program.cs
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:5221") 
});
```

### Error Handling

Comprehensive error handling in the FetchProducts component:

- Network errors (connection failures)
- JSON deserialization errors (malformed responses)
- HTTP errors (non-success status codes)
- User-friendly error messages displayed in the UI

### CORS Configuration

The backend is configured to accept requests from any origin:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});
```

### JSON Response Structure

Products are returned with nested category information:

```csharp
new
{
    Id = 1,
    Name = "Laptop",
    Price = 1200.50,
    Stock = 25,
    Category = new { Id = 101, Name = "Electronics" }
}
```

## Performance Optimizations

1. **Efficient API Calls**: Single API call on component initialization
2. **Filtering on Client**: Category filtering happens locally without additional API calls
3. **Responsive UI**: CSS Grid layout adapts to screen size
4. **Lazy Loading Ready**: Component structure supports pagination in future
5. **Caching Strategy**: Frontend displays cached data until refresh

## Testing

### Manual Testing

1. **Test Product Display**:
   - Navigate to `/fetchproducts`
   - Verify products load and display correctly

2. **Test Category Filtering**:
   - Use the filter dropdown
   - Verify products update based on selection

3. **Test Error Handling**:
   - Stop the backend server
   - Observe error message in UI
   - Use "Retry" button to reconnect

4. **Test Responsiveness**:
   - Open browser DevTools (F12)
   - Test on various screen sizes

## Deployment

### Deploying to GitHub

1. Initialize Git repository:
```bash
git init
git add .
git commit -m "Initial commit"
```

2. Create a repository on GitHub

3. Add remote and push:
```bash
git remote add origin https://github.com/yourusername/InventoryHub.git
git branch -M main
git push -u origin main
```

### Deploying to Azure

The application can be deployed to Azure App Services:

1. Right-click on projects in Visual Studio
2. Select "Publish"
3. Choose Azure App Service
4. Follow the deployment wizard

## Project Timeline

This project demonstrates the complete full-stack development workflow:

1. **Activity 1**: Generated and refined integration code for seamless front-end and back-end communication
2. **Activity 2**: Debugged and resolved integration issues (CORS, JSON deserialization, routing)
3. **Activity 3**: Implemented well-structured JSON responses with nested objects
4. **Activity 4**: Optimized performance and consolidated all components

## Best Practices Implemented

- Separation of concerns (frontend and backend)
- RESTful API design
- Proper error handling and logging
- CORS security configuration
- Responsive CSS design
- Component-based architecture
- Configuration management
- Type-safe C# code

## Common Issues and Solutions

### Issue: CORS errors in browser console
**Solution**: Ensure ServerApp is running and CORS is configured correctly. Check that the client URL matches the allowed origin.

### Issue: Products not loading
**Solution**: Check that the backend API is running on the correct port (5221). Verify network connectivity between frontend and backend.

### Issue: 404 errors on API endpoints
**Solution**: Verify the correct endpoint path is being called (`/api/productlist` not `/api/products`).

## Future Enhancements

- Add product search functionality
- Implement pagination for large datasets
- Add product add/edit/delete functionality
- Implement authentication and authorization
- Add database persistence
- Create comprehensive unit tests
- Implement caching strategy
- Add data export functionality

## Contributing

This is a demonstration project for educational purposes. For production use, consider adding:

- Unit and integration tests
- Logging framework
- API documentation (Swagger)
- Database integration
- User authentication
- Data validation
- Rate limiting

## License

This project is provided as-is for educational purposes.

## Support

For issues or questions, refer to the REFLECTION.md file for detailed information about the development process and how Microsoft Copilot assisted in building this application.

---

**Last Updated**: April 27, 2026

For more information about how this project was built, see [REFLECTION.md](REFLECTION.md).
