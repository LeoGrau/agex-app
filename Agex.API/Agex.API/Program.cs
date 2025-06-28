using Agex.API.Application.Documents.Interfaces;
using Agex.API.Application.Documents.Services;
using Agex.API.Application.Mappings;
using Agex.API.Domain.Documents.Entities;
using Agex.API.Domain.Documents.Interfaces.Repository;
using Agex.API.Infrastructure.Common.Repository;
using Agex.API.Infrastructure.Persistence.Context;
using Agex.API.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Agex.API", Version = "v1" });
    options.EnableAnnotations();
});

// Connection String
var connectionString = builder.Configuration.GetConnectionString("AgexDbConnection");

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    if (connectionString != null)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }
});

// Add controllers or other dependencies
builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection
builder.Services.AddScoped<IBaseRepository<Document, Guid>, DocumentRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();

// Automapper
builder.Services.AddAutoMapper(typeof(ModelToResourceProfile));

var app = builder.Build();

using(var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/api/hello", () => Results.Ok("Hola desde Swagger 👋"));

app.UseHttpsRedirection();
app.UseCors();

app.MapControllers();
app.Run();