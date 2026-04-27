using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Configure middleware
app.UseRouting();
app.UseCors("AllowAll");

// Define the enhanced product data with categories
var productsData = new List<dynamic>
{
    new
    {
        Id = 1,
        Name = "Laptop",
        Price = 1200.50,
        Stock = 25,
        Category = new { Id = 101, Name = "Electronics" }
    },
    new
    {
        Id = 2,
        Name = "Headphones",
        Price = 50.00,
        Stock = 100,
        Category = new { Id = 102, Name = "Accessories" }
    },
    new
    {
        Id = 3,
        Name = "USB Cable",
        Price = 15.00,
        Stock = 200,
        Category = new { Id = 102, Name = "Accessories" }
    },
    new
    {
        Id = 4,
        Name = "Monitor",
        Price = 350.00,
        Stock = 15,
        Category = new { Id = 101, Name = "Electronics" }
    }
};

// Endpoint to get all products
app.MapGet("/api/productlist", () =>
{
    try
    {
        return Results.Ok(productsData);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

// Endpoint to get a single product by ID
app.MapGet("/api/productlist/{id}", (int id) =>
{
    var product = productsData.FirstOrDefault(p => p.Id == id);
    if (product == null)
    {
        return Results.NotFound(new { error = $"Product with ID {id} not found" });
    }
    return Results.Ok(product);
});

// Endpoint to get products by category
app.MapGet("/api/productlist/category/{categoryId}", (int categoryId) =>
{
    var categoryProducts = productsData
        .Where(p => p.Category.Id == categoryId)
        .ToList();
    
    if (!categoryProducts.Any())
    {
        return Results.NotFound(new { error = $"No products found in category {categoryId}" });
    }
    return Results.Ok(categoryProducts);
});

app.Run();
