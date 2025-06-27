using Agex.API.Shared.Persistence.Context;
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

var app = builder.Build();

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