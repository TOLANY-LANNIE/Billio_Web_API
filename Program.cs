using Microsoft.OpenApi.Models;
using BillioAPI.Models;
using BillioAPI.Services;
using Microsoft.Extensions.Options;
using BillioAPI.Controllers;
using BillioAPI.Repository;

// Create a new WebApplication instance using the provided command-line arguments.
var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB settings using the app configuration for MongoDB related settings.
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));

// Register BudgetService as a singleton in the dependency injection container.
builder.Services.AddSingleton<BudgetService>();

// Add controllers to the application's services. Controllers handle incoming HTTP requests.
builder.Services.AddControllers();

// Configure API Explorer for generating OpenAPI (Swagger) documentation for API endpoints.
builder.Services.AddEndpointsApiExplorer();
// Configure Swagger generation, including specifying API information such as title, description, and version.
builder.Services.AddSwaggerGen(c =>
   {
    // Define Swagger documentation for version 1 of the API.
       c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Billio API",                         // Title of the API documentation
        Description = "Keep track of your expenses",  // Description of the API
        Version = "v1" });                            // Version of the API
   });

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Enable Swagger middleware to serve the generated Swagger JSON file.
app.UseSwagger();
// Configure Swagger UI to display the Swagger documentation for version 1 of the API.
app.UseSwaggerUI(c =>
{
    // Specify the Swagger JSON endpoint for version 1 of the API.
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Billio API V1");
});

app.UseCors(); // Use CORS middleware here
  
app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
