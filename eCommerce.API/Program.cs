using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Add infrastructure
builder.Services.AddInfrastructure();

//Add Core
builder.Services.AddCore();

// Add core
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters
        .Add(new JsonStringEnumConverter()));

// Add Automapper
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//Add Fluent Validations
builder.Services.AddFluentValidationAutoValidation();

// build web application
var app = builder.Build();

// use exception middleware
app.UseExceptionHandlingMiddleware();


// Routing
app.UseRouting();

// Authentication
app.UseAuthentication();
app.UseAuthorization();

//controller routes
app.MapControllers();

app.Run();