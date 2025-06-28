using Agex.API.Domain.Documents.Entities;
using Agex.API.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;

namespace Agex.API.Infrastructure.Persistence.Context;

public class AppDbContext(DbContextOptions options, IWebHostEnvironment environment) : DbContext(options)
{
    public DbSet<Document> Documents { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DocumentSeeding());
        
    }
}