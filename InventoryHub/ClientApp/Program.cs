using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder
    .RootComponents
    .Add<App>("#app");

// Configure HttpClient to point to the backend API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5221") });

await builder.Build().RunAsync();
