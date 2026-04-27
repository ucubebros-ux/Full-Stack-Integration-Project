# InventoryHub - Setup Guide

## Prerequisites

Before you begin, ensure you have the following installed:

- **.NET 8.0 SDK** - Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Git** - Download from [git-scm.com](https://git-scm.com)
- **Visual Studio Code** or **Visual Studio 2022** (recommended)
- A modern web browser (Chrome, Firefox, Edge, or Safari)

## Installation Steps

### Step 1: Clone or Download the Repository

```bash
# If cloning from GitHub
git clone https://github.com/yourusername/InventoryHub.git
cd InventoryHub
```

Or if you have the files locally:
```bash
cd path/to/InventoryHub
```

### Step 2: Verify .NET Installation

Open a terminal and verify your .NET SDK installation:

```bash
dotnet --version
```

You should see version 8.0.0 or later.

### Step 3: Restore Dependencies

In the project root directory, run:

```bash
dotnet restore
```

This downloads all required NuGet packages for both ClientApp and ServerApp.

### Step 4: Build the Solution

Build the entire solution to ensure all projects compile correctly:

```bash
dotnet build
```

You should see "Build succeeded" with no errors.

## Running the Application

### Option 1: Running in Two Terminal Windows (Recommended for Development)

#### Terminal 1: Start the Backend API

```bash
cd ServerApp
dotnet run
```

You should see output similar to:
```
info: Microsoft.AspNetCore.Hosting.Diagnostics
      Now listening on: http://localhost:5221
```

**Important**: Leave this terminal running.

#### Terminal 2: Start the Frontend Application

In a new terminal window:

```bash
cd ClientApp
dotnet run
```

You should see output including:
```
info: Microsoft.AspNetCore.Hosting.Diagnostics
      Now listening on: http://localhost:5000
```

The browser should automatically open to the application homepage.

### Option 2: Using Visual Studio

1. Open `FullStackSolution.sln` with Visual Studio
2. Set startup behavior to start both projects:
   - Right-click Solution → Properties
   - Select "Multiple startup projects"
   - Set both ClientApp and ServerApp to "Start"
3. Press **F5** or click Run

### Option 3: Using Visual Studio Code

1. Open the repository folder in VS Code
2. Install the C# extension by OmniSharp if prompted
3. Terminal 1:
   ```bash
   cd ServerApp
   dotnet run
   ```

4. In a new VS Code terminal (Terminal 2):
   ```bash
   cd ClientApp
   dotnet run
   ```

## Accessing the Application

Once both applications are running:

1. **Frontend**: Open your browser to `http://localhost:5000`
2. **Backend API**: View API responses at `http://localhost:5221/api/productlist`

### Navigation

- **Home Page**: Shows welcome message and application overview
- **Products Page**: Click "View Products" or navigate to `http://localhost:5000/fetchproducts`
- **API Endpoints**:
  - All Products: `http://localhost:5221/api/productlist`
  - Single Product: `http://localhost:5221/api/productlist/1`
  - Products by Category: `http://localhost:5221/api/productlist/category/101`

## Testing the Integration

### Test 1: Display Products

1. Navigate to `/fetchproducts`
2. Verify that a list of products displays with:
   - Product names (Laptop, Headphones, etc.)
   - Prices
   - Stock levels
   - Category badges

### Test 2: Filter by Category

1. Use the category dropdown filter
2. Select "Electronics"
3. Verify only electronics products display
4. Select "Accessories"
5. Verify only accessories display

### Test 3: Error Handling

1. Stop the backend server (Ctrl+C in ServerApp terminal)
2. On the product page, click the "Retry" button
3. You should see the error message: "Network error: Unable to connect to the server"
4. Restart the backend: `dotnet run`
5. Click "Retry" again - products should load

### Test 4: API Testing

Use curl or Postman to test endpoints directly:

```bash
# Get all products
curl http://localhost:5221/api/productlist

# Get single product
curl http://localhost:5221/api/productlist/1

# Get products by category
curl http://localhost:5221/api/productlist/category/101
```

## Troubleshooting

### Issue: "No .NET SDKs were found"

**Solution**: 
- Ensure .NET 8.0 SDK is installed: `dotnet --version`
- Restart terminal after installation
- Check environment variables for PATH

### Issue: Port already in use

**Error**: "Address already in use"

**Solution**:
- Change the port in `ServerApp/Properties/launchSettings.json`
- Or find and kill the process using the port:
  ```bash
  # On Windows
  netstat -ano | findstr :5221
  taskkill /PID <PID> /F
  ```

### Issue: CORS errors in browser console

**Check**:
1. Backend server is running
2. Frontend URL matches CORS policy
3. CORS is enabled in ServerApp/Program.cs

### Issue: Products don't load

**Checklist**:
- Backend is running on port 5221
- Frontend can reach `http://localhost:5221/api/productlist`
- Check browser console (F12) for error messages
- Verify network tab shows successful API calls

## Project Structure Reference

```
InventoryHub/
├── ClientApp/                    # Blazor Frontend
│   ├── Components/Pages/         # Razor pages
│   │   ├── Home.razor           # Landing page
│   │   └── FetchProducts.razor  # Product listing
│   ├── wwwroot/                 # Static assets
│   ├── Program.cs               # Startup configuration
│   ├── App.razor                # Root component
│   ├── app.css                  # Styles
│   └── ClientApp.csproj         # Project file
│
├── ServerApp/                   # ASP.NET Core API
│   ├── Program.cs               # API configuration
│   ├── Properties/              # Configuration
│   ├── appsettings.json         # Settings
│   └── ServerApp.csproj         # Project file
│
├── FullStackSolution.sln        # Solution file
├── README.md                    # Project overview
├── REFLECTION.md                # Development summary
├── SETUP.md                     # This file
└── .gitignore                   # Git ignore rules
```

## Next Steps

### For Learning:

1. Examine the code in FetchProducts.razor to understand:
   - How HttpClient is injected
   - How data is fetched and deserialized
   - How error handling works

2. Review ServerApp/Program.cs to see:
   - How endpoints are defined
   - How CORS is configured
   - How JSON responses are structured

3. Study the CSS in app.css to understand:
   - Responsive grid layout
   - Component styling
   - Mobile-first design

### For Development:

1. **Add Functionality**:
   - Add product search
   - Add add/edit/delete features
   - Add sorting options

2. **Improve Performance**:
   - Add caching
   - Implement pagination
   - Add lazy loading

3. **Enhance Security**:
   - Add authentication
   - Validate inputs
   - Implement rate limiting

4. **Add Testing**:
   - Create unit tests
   - Add integration tests
   - Test error scenarios

## Getting Help

- Check the README.md for feature documentation
- Review REFLECTION.md for development insights
- Check the code comments for implementation details
- Consult the official documentation:
  - [Blazor Docs](https://docs.microsoft.com/en-us/aspnet/core/blazor)
  - [ASP.NET Core Docs](https://docs.microsoft.com/en-us/aspnet/core)
  - [.NET API Docs](https://docs.microsoft.com/en-us/dotnet/api)

## Deployment

For deployment information, see README.md section "Deployment".

---
