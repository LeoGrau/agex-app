using Microsoft.EntityFrameworkCore;

namespace Agex.API.Shared.Persistence.Context;

public class AppDbContext(DbContextOptions options, IWebHostEnvironment environment) : DbContext(options)
{
    
}