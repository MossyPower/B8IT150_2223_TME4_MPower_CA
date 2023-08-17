using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;
using ProductsApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register ProductsDbContext at startup
var connectionString = builder.Configuration
    .GetConnectionString("ProductApiDBConnection") ??
    throw new InvalidOperationException("Connection string 'ProductApiDBConnection' not found.");

builder.Services.AddDbContext<ProductsDbContext>(options =>
    options.UseSqlite(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add for SeedData on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
